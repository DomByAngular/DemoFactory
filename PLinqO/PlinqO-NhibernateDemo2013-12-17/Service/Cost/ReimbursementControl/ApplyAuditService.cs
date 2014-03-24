using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BusinessObject.CostBo;
using HuatongApply.Data;
using Domain.common;
using IService.ICost.IReimbursement;
using IService.ICost.IReimbursement;

namespace Service.Cost.ReimbursementControl
{

	/***********************************************

	** 作者： 杨双

	** 创始时间：2013-12-03

	** 修改人：

	** 修改时间：

	** 修改人：

	** 修改时间：

	** 描述：

	** 定义成本管理中报销审核服务接口
      
	**************************************************/
	public class ApplyAuditService : IApplyAuditService
	{
		/// <summary>
		/// 获取审核的报销记录的分页数据
		/// add by ys on 2013-12-12
		/// </summary>
		/// <param name="pageSize"> </param>
		/// <param name="order"></param>
		/// <param name="sort"></param>
		/// <param name="applyRecordBo"></param>
		/// <param name="pageIndex"> </param>
		/// <returns></returns>
		public Page<ApplyRecordBO> GetAuditApplyRecords(int pageIndex, int pageSize, string order, string sort, ApplyRecordBO applyRecordBo)
		{
			Page<ApplyRecordBO> applyRecordsPage = null;
			Page<Applyrecord> page = null;
			try
			{
				var wheres = new List<Expression<Func<Applyrecord, bool>>>();
				//0：新增，1：部门审核，2：财务审核，3：最终审核，4：已支付
				Expression<Func<Applyrecord, bool>> include = p => p.AuditStatus != 4;
				wheres.Add(include);//尚未支付的报销单
				if (!string.IsNullOrEmpty(applyRecordBo.ApplyBy))
				{
					Expression<Func<Applyrecord, bool>> where = p => p.ApplyBy.Contains(applyRecordBo.ApplyBy);
					wheres.Add(where);
				}
				if (applyRecordBo.OrId != null && applyRecordBo.OrId != 0 && applyRecordBo.OrId != -1)
				{
					Expression<Func<Applyrecord, bool>> where = p => p.OrId == applyRecordBo.OrId;
					wheres.Add(where);
				}
				if ((!string.IsNullOrEmpty(applyRecordBo.ApplyBy)) && applyRecordBo.ApplyBy.Contains("%"))
				{
					Expression<Func<Applyrecord, bool>> where = p => p.ApplyBy.Contains(applyRecordBo.ApplyBy);
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
		/// 根据报销单的id进行报销状态的审核
		/// 索引0存放处理标志，false失败， true成功
		/// 索引1处存放处理提示
		/// 审核2处存放失败的记录条数
		/// add by ys on 2013-12-12
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		public string[] AuditApplyRecordByIds(Int32[] ids)
		{
			var results=new string[3];//审核结果
			var infos = new string[3];
			bool[] setResult = new bool[ids.Length];//本批报销单审核结果数组
			results[0] = "false";
			string userName = "yangshuang";//UserInfo.GetUserName();
			//string loginName = UserInfo.GetLoginName();
			//List<RightBO> rights = UserInfo.GetUserRight();

			//if(string.IsNullOrEmpty(userName)||rights==null||rights.Count==0)
			if((string.IsNullOrEmpty(userName)))
			{
				results[1] = "审核失败，请您重新登陆";
				return results;
			}
			else
			{
				using (var  context=new HuatongApplyContext())
				{
					try
					{
						context.BeginTransaction();
						infos=GetCurrentRoleNameAndNameByUserName(context,userName);
						infos[2] = userName;
						if(string.IsNullOrEmpty(infos[0])||string.IsNullOrEmpty(infos[1]))
						{
							results[1] = "审核失败，您无权进行审核";
						}
						else
						{
							bool singleresult = false;
							for (int i = 0; i < ids.Length;i++ )
							{
								var idtemp = ids[i];//取出单条记录id
								setResult[i] = false;//单条记录审核标志，默认为false
								var tempRecord = context.Applyrecord.FirstOrDefault(p => p.ApplyId == idtemp);
								if (tempRecord != null)
								{
									//写入审核标志和审核人，返回审核状态
									SetAudit(tempRecord, infos, out singleresult);
									setResult[i] = singleresult;	
								}
								else
								{
									LogHelper.WriteLog(string.Format("未找到id为{0}的报销单", idtemp));
								}
							}	
						}
						context.CommitTransaction();
						int successRecords=setResult.Count(p => p == true);
						int faileRecords=setResult.Count(p => p == false);
						if (successRecords==ids.Length)
						{
							results[0] = "true";
							results[1] = "批量审核成功";
						}
						else if(successRecords!=ids.Length&&faileRecords!=0&&faileRecords!=ids.Length)
						{
							results[0] = "partial";
							results[1] = "部分审核成功";
							results[2] = faileRecords.ToString();
						}
						else
						{
							results[0] = "false";
							results[1] = "批量审核失败";
						}
					}
					catch (Exception e)
					{
						context.RollbackTransaction();
						results[1] = "批量审核过程中出现异常";
						LogHelper.WriteLog(string.Format("ApplyAuditService.AuditApplyRecordByIds({0}),批量审核报销单出错",string.Join(",",ids)),e);
					}
				}
			}
			return results;
		}

		/// <summary>
		/// 根据用户名获取用户姓名和角色
		/// 索引0处存放角色名称
		/// 索引1处存放当前登陆用户的真实姓名
		/// add by ys on 2013-12-13
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		string [] GetCurrentRoleNameAndNameByUserName(HuatongApplyContext context,string userName)
		{
			string[] results=new string[3];
			return results;
		}

		/// <summary>
		/// 设置审核人和审核标志
		/// 
		/// add by ys on 2013-12-13
		/// </summary>
		/// <param name="record"></param>
		/// <param name="infos">infos，索引0处角色，1处用户姓名</param>
		/// <returns></returns>
		 Applyrecord SetAudit(Applyrecord record,string[]infos,out bool auditResult)
		{
			bool result = true;
			 switch (infos[0])
							{
					 case "部门主管":
									{
										if ((record.AuditStatus==0||record.AuditStatus==1)&&(string.IsNullOrEmpty(record.DepAuditBy)))
										{
											record.AuditStatus = 1;
											record.DepAuditBy = infos[1];
											record.ModifiedBy = infos[2];
											record.ModifiedOn = DateTime.Now;
										}
										else
										{
											result = false;
										}
									}
					 break;
					 case "财务主管":
									{
										if ((record.AuditStatus == 1||record.AuditStatus==2) && (!string.IsNullOrEmpty(record.DepAuditBy)))
										{
											record.AuditStatus = 2;
											record.FinanceAuditBy = infos[1];
											record.ModifiedBy = infos[2];
											record.ModifiedOn = DateTime.Now;
										}
										else
										{
											result = false;
										}
									}
									break;
					case "最终审核":
							{
								if ((record.AuditStatus==3||record.AuditStatus==2)&&(!string.IsNullOrEmpty(record.FinanceAuditBy)))
								{
									record.AuditStatus = 3;
									record.FinalAuditBy = infos[1];
									record.ModifiedBy = infos[2];
									record.ModifiedOn = DateTime.Now;
								}
								else
								{
									result = false;
								}
							}
							break;
							default:
									{
										result = false;
									}
									break;
							}
			auditResult = result;
			return record;
		}
	}
}
