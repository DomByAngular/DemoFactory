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

	**   报销记录项管理下的相关服务方法
**********************************************/
	public class ReimbursementService : IReimbursementService
	{
		/// <summary>
		/// 添加报销项
		/// add by ys on 2013-12-02
		/// </summary>
		/// <param name="applyitemBo"></param>
		/// <returns></returns>
		public bool AddApplyitem(ApplyitemBO applyitemBo)
		{
			bool result = false;
			if(applyitemBo==null)
			{
				throw new ArgumentException("applyitemBo");
			}
			if (applyitemBo.ItemId.HasValue)
			{
				return result;
			}
			else
			{
				try
				{
					Mapper.Reset();
					Mapper.CreateMap<ApplyitemBO, Applyitem>();
					var entity = Mapper.Map<ApplyitemBO, Applyitem>(applyitemBo);
					entity.CreatedBy = "非系统访问";
					entity.CreatedOn = DateTime.Now;
					using (var context=new HuatongApplyContext())
					{
						context.BeginTransaction();
						context.Applyitem.InsertOnSubmit(entity);
						context.CommitTransaction();
						result = true;
					}
				}
				catch (Exception e)
				{
					result = false;
					LogHelper.WriteLog(string.Format("ReimbursementService.AddApplyItem({0})",applyitemBo),e);
				}
				return result;
			}
		}

		/// <summary>
		/// 添加报销项
		/// add by ys on 2013-12-02
		/// </summary>
		/// <param name="applyitemBo"></param>
		/// <returns></returns>
		public bool UpdateApplyitem(ApplyitemBO applyitemBo)
		{
			bool result = false;
			if (applyitemBo == null)
			{
				throw new ArgumentException("applyitemBo");
			}
			if (!applyitemBo.ItemId .HasValue)
			{
				return result;
			}
			else
			{
				try
				{
					using (var context = new HuatongApplyContext())
					{
						context.BeginTransaction();
						var entity=context.Applyitem.FirstOrDefault(p => p.ItemId == applyitemBo.ItemId);
						if(entity!=null)
						{
							entity.ItemName = applyitemBo.ItemName;
							entity.ModifiedBy = applyitemBo.ModifiedBy;
							entity.ModifiedOn = DateTime.Now;
							result = true;
						}
						else
						{
							result = false;
						}
						context.CommitTransaction();
					}
				}
				catch (Exception e)
				{
					result = false;
					LogHelper.WriteLog(string.Format("ReimbursementService.UpdateApplyitem({0})", applyitemBo), e);
				}
				return result;
			}
		}

		/// <summary>
		/// 根据id集合删除报销项
		/// add by ys on 2013-12-02
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		public bool DeleteApplyitemByIds(Int32[] ids)
		{
			bool result = false;
			var entities = ids.Select(p => new Applyitem() {ItemId = p});
			try
			{
				using (var context=new HuatongApplyContext())
				{
					context.BeginTransaction();
					context.Applyitem.DeleteAllOnSubmit(entities);
					context.CommitTransaction();
					result = true;
				}
			}
			catch (Exception e)
			{
				result = false;
				LogHelper.WriteLog(string.Format("ReimbursementService.DeleteApplyitemByIds({0})", string.Join(",",ids)), e);
			}
			return result;
		}

		/// <summary>
		/// 根据id查找报销项
		/// add by ys on 2013-12-02
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ApplyitemBO GetApplyitemById(int id)
		{
			ApplyitemBO bo = null;
			Applyitem entity = null;
			try
			{
				using (var context=new HuatongApplyContext())
				{
					context.BeginTransaction();
					entity=context.Applyitem.FirstOrDefault(p => p.ItemId == id);
					context.CommitTransaction();
				}
				Mapper.Reset();
				Mapper.CreateMap<Applyitem, ApplyitemBO>();
				bo = Mapper.Map<Applyitem, ApplyitemBO>(entity);
			}
			catch (Exception e)
			{
				LogHelper.WriteLog(string.Format("ReimbursementService.GetApplyitemById({0})", id), e);
			}
			return bo;
		}

		/// <summary>
		/// 项目名称存在性检查
		/// true代表已经存在
		/// false代表不存在
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool CheckUniqueApplyitemName(string name)
		{
			bool result = true;
			using (var context=new HuatongApplyContext())
			{
				context.BeginTransaction();
				var temp=context.Applyitem.Count(p => p.ItemName == name);
				result = temp != 0;
				context.CommitTransaction();
			}
			return result;
		}

		/// <summary>
		/// 获取报销项列表
		/// add by ys on 2013-12-02
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="order"></param>
		/// <param name="sort"></param>
		/// <param name="applyitemBo"></param>
		/// <returns></returns>
		public Page<ApplyitemBO> GetApplyitems(int pageIndex, int pageSize, string order, string sort, ApplyitemBO applyitemBo)
		{
			Page<ApplyitemBO> applyItemsPage=null;
			Page<Applyitem> page = null;
			try
			{
				var wheres = new List<Expression<Func<Applyitem, bool>>>();
				if (!string.IsNullOrEmpty(applyitemBo.ItemName))
				{
					Expression<Func<Applyitem, bool>> where = p => p.ItemName.Contains(applyitemBo.ItemName);
					wheres.Add(where);
				}
				//排序,默认创建时间来排序
				Expression<Func<Applyitem, Object>> orderBy = null;
				switch (sort)
				{
					case "ItemId":
						orderBy = o => o.ItemId;
						break;
					default:
						orderBy = o => o.CreatedOn;
						break;
				}
				//分页筛选器
				Func<IQueryable<Applyitem>, List<Applyitem>> selector =
					u =>u.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
				using (var context = new HuatongApplyContext())
				{
					context.BeginTransaction();
					page = context.Applyitem.GetPagedListQuery(pageIndex, pageSize, wheres, orderBy, selector,false);
					context.CommitTransaction();
				}
				Mapper.CreateMap<Page<Applyitem>, Page<ApplyitemBO>>();
				Mapper.CreateMap<Applyitem, ApplyitemBO>();
				applyItemsPage = Mapper.Map<Page<Applyitem>, Page<ApplyitemBO>>(page);
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog(string.Format("ReimbursementService.GetApplyitems({0},{1},{2},{3},{4})异常",
					pageIndex, pageSize,order,sort, applyitemBo), ex);
			}
			return applyItemsPage;
		}

		/// <summary>
		/// 获取所有申请项目
		/// add by ys on 2013-12-06
		/// </summary>
		/// <returns></returns>
		public List<ApplyitemBO> GetAllApplyItems()
		{
			var entities = new List<Applyitem>();
			var bos = new List<ApplyitemBO>();
			try
			{
				using (var context=new HuatongApplyContext())
				{
					entities=context.Applyitem.Where(p => p.ItemId != -1).ToList();
					Mapper.Reset();
					Mapper.CreateMap<Applyitem, ApplyitemBO>();
					bos=Mapper.Map<List<Applyitem>, List<ApplyitemBO>>(entities);
				}
			}
			catch (Exception e)
			{
				LogHelper.WriteLog(string.Format("ReimbursementService.GetAllApplyItems()"),e);
			}
			return bos;
		}
	}
}
