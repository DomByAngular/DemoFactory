
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BusinessObject.CostBo;
using Domain.common;
using HuatongApply.Data;
using IService.ICost.IReimbursement;

namespace Service.Cost.ReimbursementControl
{
	/***********************************************

	** 作者： 杨双

	** 创始时间：2013-11-29

	** 修改人：

	** 修改时间：

	** 修改人：

	** 修改时间：

	** 描述：

	** 定义成本管理中报销记录服务接口
      
	**************************************************/
	public class ApplyRecordService : IApplyRecordService
	{
		/// <summary>
		/// 新增
		/// add by ys on 2013-12-03
		/// </summary>
		/// <param name="applyRecordBo"></param>
		/// <returns></returns>
		public bool AddApplyRecord(ApplyRecordBO applyRecordBo)
		{
			bool result = false;
			if (applyRecordBo == null)
			{
				throw new ArgumentException("applyitemBo");
			}
			if (applyRecordBo.ApplyId.HasValue)
			{
				return result;
			}
			else
			{
				List<Applydetail> details=new List<Applydetail>();
				double recordTotalPrice = default(float);//报销单总价
				try
				{

					Mapper.Reset();
					var map=Mapper.CreateMap<ApplyRecordBO, Applyrecord>();
					Mapper.CreateMap<ApplydetailBO, Applydetail>();
					var entity = Mapper.Map<ApplyRecordBO, Applyrecord>(applyRecordBo);
					entity.CreatedBy =  "杨双";
					entity.CreatedOn = DateTime.Now;
					entity.AuditStatus = 0;//新增报销项的状态为‘未审核’
					#region
					if (entity.OrId==0)
					{
						entity.OrId = null;
					}
					if(entity.IsCar!=null&&entity.IsCar.GetValueOrDefault()==1)//是车辆成本
					{
						entity.IsCar = 1;
					}
					else
					{
						entity.IsCar = 0;
						entity.CarNo = null;
					}
					#endregion
					using (var context = new HuatongApplyContext())
					{
						try
						{
							context.BeginTransaction();
							context.Applyrecord.InsertOnSubmit(entity);
							context.SubmitChanges(); //先Submmit下产生报销单
							foreach (var applydetaiBo in applyRecordBo.ApplydetailBoList)
							{
								Applydetail singleDetail = new Applydetail();
								singleDetail.Applyitem =
									context.Applyitem.FirstOrDefault(p => p.ItemId == applydetaiBo.ItemId.GetValueOrDefault());
								singleDetail.Applyrecord = entity;
								singleDetail.CreatedOn = entity.CreatedOn;
								singleDetail.CreatedBy = entity.CreatedBy;
								singleDetail.Count = applydetaiBo.Count;
								singleDetail.Price = applydetaiBo.Price;
								details.Add(singleDetail);
								recordTotalPrice = recordTotalPrice +
												   (singleDetail.Count.GetValueOrDefault()) * (singleDetail.Price.GetValueOrDefault());
							}
							entity.ApplydetailList = details;
							entity.Price = recordTotalPrice; //提交事务产生报销详情记录
							context.CommitTransaction();
							result = true;
						}
						catch (Exception e)
						{
							context.RollbackTransaction();
							result = false;
							LogHelper.WriteLog(string.Format("ApplyRecordSevice.AddApplyRecord({0})，事务错误提交过程中产生错误", applyRecordBo), e);
						}
					}
				}
				catch (Exception e)
				{
					result = false;
					LogHelper.WriteLog(string.Format("ApplyRecordSevice.AddApplyRecord({0})", applyRecordBo), e);
				}
				return result;
			}
		}

		/// <summary>
		/// 更新
		/// add by ys on 2013-12-03
		/// </summary>
		/// <param name="applyRecordBo"></param>
		/// <returns></returns>
		public bool UpdateApplyRecord(ApplyRecordBO applyRecordBo)
		{
			bool result = false;
			Applyrecord entity = null;
			if (applyRecordBo == null)
			{
				throw new ArgumentException("applyRecordBo");
			}
			if (!applyRecordBo.ApplyId.HasValue)
			{
				return result;
			}
			else
			{
				try
				{
					List<Applydetail> details = new List<Applydetail>();
					double recordTotalPrice = default(float);//报销单总价
					using (var context = new HuatongApplyContext())
					{
						try
						{
							context.BeginTransaction();
							entity = context.Applyrecord.FirstOrDefault(p => p.ApplyId == applyRecordBo.ApplyId);
							if(entity!=null&&entity.ApplydetailList.Count>=0)
							{
								var deleteDetais=entity.ApplydetailList.ToList();
								entity.ApplydetailList.Clear();
								//context.Applydetail.DeleteAllOnSubmit(deleteDetais);
								context.SubmitChanges();
								foreach (var applydetaiBo in applyRecordBo.ApplydetailBoList)
								{
									
										Applydetail singleDetail = new Applydetail();
										singleDetail.Applyitem =
											context.Applyitem.FirstOrDefault(p => p.ItemId == applydetaiBo.ItemId.GetValueOrDefault());
										singleDetail.Applyrecord = entity;
										singleDetail.CreatedOn = DateTime.Now;
										singleDetail.CreatedBy = "杨双"; ;
										singleDetail.Count = applydetaiBo.Count;
										singleDetail.Price = applydetaiBo.Price;
										details.Add(singleDetail);
										recordTotalPrice = recordTotalPrice +
														   (singleDetail.Count.GetValueOrDefault()) * (singleDetail.Price.GetValueOrDefault());
								}
								context.Applydetail.InsertAllOnSubmit(details);
								context.SubmitChanges();//Submmit清除所有报销子项
								//创建报销子项
								entity.Price = recordTotalPrice; //提交事务产生报销详情记录
								entity.ModifiedBy =  "杨双";
								entity.ModifiedOn = DateTime.Now;
								context.CommitTransaction();
								result = true;
							}
							else
							{
								result = false;
							}
						}
						catch (Exception e)
						{
							context.RollbackTransaction();
							result = false;
							LogHelper.WriteLog(string.Format("ApplyRecordSevice.UpdateApplyRecord({0})，事务错误提交过程中产生错误", applyRecordBo), e);
						}
					}
				}
				catch (Exception e)
				{
					result = false;
					LogHelper.WriteLog(string.Format("ApplyRecordSevice.UpdateApplyRecord({0})", applyRecordBo), e);
				}
				return result;
			}
		}
		
		/// <summary>
		/// 批量删除
		/// add by ys on 2013-12-03
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		public bool DeleteApplyRecordByIds(int[] ids)
		{
			bool result = false;
			var entities = ids.Select(p => new Applyrecord() { ApplyId = p });
			try
			{
				using (var context = new HuatongApplyContext())
				{
					context.BeginTransaction();
					context.Applyrecord.DeleteAllOnSubmit(entities);
					context.CommitTransaction();
					result = true;
				}
			}
			catch (Exception e)
			{
				result = false;
				LogHelper.WriteLog(string.Format("ApplyRecordSevice.DeleteApplyRecordByIds({0})", string.Join(",", ids)), e);
			}
			return result;
		}
		/// <summary>
		/// 单个查询
		/// add by ys on 2013-12-03
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ApplyRecordBO GetApplyRecordById(int id)
		{
			ApplyRecordBO bo = null;
			Applyrecord entity = null;
			try
			{
				using (var context = new HuatongApplyContext())
				{
					context.BeginTransaction();
					entity = context.Applyrecord.FirstOrDefault(p => p.ApplyId == id);
					context.CommitTransaction();
				}
				Mapper.Reset();
				Mapper.CreateMap<Applyrecord, ApplyRecordBO>();
				bo = Mapper.Map<Applyrecord, ApplyRecordBO>(entity);
			}
			catch (Exception e)
			{
				LogHelper.WriteLog(string.Format("ApplyRecordSevice.GetApplyRecordById({0})", id), e);
			}
			return bo;
		}

		public bool CheckUniqueApplyRecordName(string name)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// 报销记录分页
		/// add by ys on 2013-12-03
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="order"></param>
		/// <param name="sort"></param>
		/// <param name="applyRecordBo"></param>
		/// <returns></returns>
		public Page<ApplyRecordBO> GetApplyRecords(int pageIndex, int pageSize, string order, string sort, ApplyRecordBO applyRecordBo)
		{
			Page<ApplyRecordBO> applyRecordsPage = null;
			Page<Applyrecord> page = null;
			try
			{
				var wheres = new List<Expression<Func<Applyrecord, bool>>>();
				if (!string.IsNullOrEmpty(applyRecordBo.ApplyBy))
				{
					Expression<Func<Applyrecord, bool>> where = p => p.ApplyBy.Contains(applyRecordBo.ApplyBy);
					wheres.Add(where);
				}
				if (applyRecordBo.OrId!=null&&applyRecordBo.OrId!=0&&applyRecordBo.OrId!=-1)
				{
					Expression<Func<Applyrecord, bool>> where = p => p.OrId==applyRecordBo.OrId;
					wheres.Add(where);
				}
				if (!string.IsNullOrEmpty(applyRecordBo.ApplyBy))
				{
					Expression<Func<Applyrecord, bool>> where = p => p.ApplyBy .Contains(applyRecordBo.ApplyBy);
					wheres.Add(where);
				}
				if (!string.IsNullOrEmpty(applyRecordBo.OrName))
				{
					Expression<Func<Applyrecord, bool>> where = p => p.OrName.Contains(applyRecordBo.OrName);
					wheres.Add(where);
				}
				//排序,默认创建时间来排序
				Expression<Func<Applyrecord, Object>> orderBy = null;
				switch (sort)
				{
					case "ApplyId":
						orderBy = o => o.ApplyId;
						break;
					default:
						orderBy = o => o.CreatedOn;
						break;
				}
				//分页筛选器
				Func<IQueryable<Applyrecord>, List<Applyrecord>> selector =
					u => u.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
				using (var context = new HuatongApplyContext())
				{
					context.BeginTransaction();
					page = context.Applyrecord.GetPagedListQuery(pageIndex, pageSize, wheres, orderBy, selector, false);
					context.CommitTransaction();
				}
				Mapper.CreateMap<Page<Applyrecord>, Page<ApplyRecordBO>>();
				Mapper.CreateMap<Applyrecord, ApplyRecordBO>();
				applyRecordsPage = Mapper.Map<Page<Applyrecord>, Page<ApplyRecordBO>>(page);
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog(string.Format("ApplyRecordService.GetApplyRecords({0},{1},{2},{3},{4})异常",
					pageIndex, pageSize, order, sort, applyRecordBo), ex);
			}
			return applyRecordsPage;
		}

		/// <summary>
		/// 根据报项项的id获取该报销项目下的报销子项
		/// add by ys on 2013-12-04
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<ApplydetailBO> GetApplyDetailsByRecordId(int id)
		{
			Applyrecord entity = null;
			List<Applydetail>detailEntities= null;
			List<ApplydetailBO> detailBos = new List<ApplydetailBO>();
			try
			{
				using (var context=new HuatongApplyContext())
				{
					entity=context.Applyrecord.FirstOrDefault(p => p.ApplyId == id);
					if (entity != null)
					{
						detailEntities = entity.ApplydetailList.ToList();
					}
					Mapper.Reset();
					Mapper.CreateMap<Applydetail, ApplydetailBO>();
					Mapper.CreateMap<Applyitem, ApplyitemBO>();
					Mapper.CreateMap<Applyrecord, ApplyRecordBO>();
					detailBos=Mapper.Map<List<Applydetail>, List<ApplydetailBO>>(detailEntities);
				}
				return detailBos;
			}
			catch (Exception e)
			{
				LogHelper.WriteLog(string.Format("ApplyRecordService.GetApplyDetailsByRecordId({0})",id),e);
				return detailBos;
			}
			
		}

		/// <summary>
		/// 通过存储过程调用，获取指定部门的所有报销单信息
		/// add by ys on 2013-12-15
		/// </summary>
		/// <param name="orId"></param>
		/// <returns></returns>
		public List<ApplyRecordBO> GetApplyRecordBosByCallProcedures(Int32 orId)
		{
			List<ApplyRecordBO> result=new List<ApplyRecordBO>();
			try
			{
				using (var context = new HuatongApplyContext())
				{
					var list = context.Advanced.DefaultSession.GetNamedQuery("GetDepartMentApplyRecords")
						.SetInt32("pOrId", orId)
						.List<object[]>();

					result = list.Select(q => new ApplyRecordBO()
					{
						ApplyId = Convert.ToInt32(q[0]),
						OrId = Convert.ToInt32(q[1]),
						Price = Convert.ToDouble(q[2]),
						Currency = Convert.ToString(q[3]),
						ApplyBy = Convert.ToString(q[4]),
						ApplyOn = Convert.ToDateTime(q[5]),
						Description = Convert.ToString(q[6]),
						IsCar = Convert.ToInt32(q[7]),
						CarNo = Convert.ToString(q[8]),
						AuditStatus = Convert.ToInt32(q[9]),
						DepAuditBy = Convert.ToString(q[10]),
						FinanceAuditBy = Convert.ToString(q[10]),
						FinalAuditBy = Convert.ToString(q[10]),
						CreatedOn = Convert.ToDateTime(q[10]),
						CreatedBy = Convert.ToString(q[10])
					}).ToList();
				}
			}
			catch (Exception e)
			{
				LogHelper.WriteLog(string.Format("ApplyRecordService.GetApplyRecordBosByCallProcedures({0})",orId),e);
			}
			return result;
		}

		/// <summary>
		/// 通过视图调用，获取指定部门的所有报销单信息
		/// add by ys on 2013-12-15
		/// </summary>
		/// <returns></returns>
		public List<ApplyRecordBO> GetApplyRecordBosByCallView()
		{
			List<ApplyRecordBO> recordBos=new List<ApplyRecordBO>();
			try
			{
				using (var context = new HuatongApplyContext())
				{
					var tempViewDatas = context.Getallrapplyecord.ToList();
					recordBos=tempViewDatas.Select(p => new ApplyRecordBO()
					{
						ApplyBy = p.ApplyBy,
						ApplyOn = p.ApplyOn,
						ApplyId = p.ApplyId,
						AuditStatus = p.AuditStatus,
						FinalAuditBy = p.FinalAuditBy,
						DepAuditBy = p.DepAuditBy,
						CreatedBy = p.CreatedBy,
						OrId = p.OrId,
						OrName = p.OrName,
						CreatedOn = p.CreatedOn,
						Currency = p.Currency

					}).ToList();
				}
			}
			catch (Exception)
			{
				//异常写入
			}
			return recordBos;
		}
	}
}
