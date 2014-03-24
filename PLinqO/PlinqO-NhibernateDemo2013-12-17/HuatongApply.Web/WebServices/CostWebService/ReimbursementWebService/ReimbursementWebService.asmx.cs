using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using BusinessObject.CostBo;
using Domain.common;
using HuaTongSystem.Models;
using Service.Cost.ReimbursementControl;

namespace HuaTongSystem.WebServices.CostWebService.ReimbursementWebService
{
	/********************************************************************************

      ** 作者： 杨双

      ** 创始时间：2013-11-29

      ** 修改人：

      ** 修改时间：

      ** 修改人：

      ** 修改时间：

      ** 描述：

      ** 定义成本管理模块->报销管理->报销项目后台服务文件
      
  *************************************************************************************/
	/// <summary>
	/// ReimbursementWebService 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
	 [System.Web.Script.Services.ScriptService]
	public class ReimbursementWebService : System.Web.Services.WebService
	{
		private ReimbursementService iservice { get; set; }  
		public ReimbursementWebService ()
		{
			iservice = new ReimbursementService();	
		}

		/// <summary>
		/// 获取分页数据
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="order"></param>
		/// <param name="sort"></param>
		/// <param name="applyItemBo"></param>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		[ScriptMethod]
		public object GetApplyItems(int pageIndex,int pageSize,string order,string sort,ApplyitemBO applyItemBo)
		{
			if(!string.IsNullOrEmpty(applyItemBo.DepartName)&&applyItemBo.DepartName.Contains("%"))
			{
				applyItemBo.DepartName = applyItemBo.DepartName.Replace("%", @"\%");
			}
			var pageDatas=iservice.GetApplyitems(pageIndex, pageSize, order, sort, applyItemBo);
			if(pageDatas==null||pageDatas.ListT==null)
			{
				return new {total = 0, rows = new List<string>{}};
			}
			return new {total=pageDatas.TotalCount,rows=pageDatas.ListT};
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="applyitemBo"></param>
		/// <returns></returns>
		[ScriptMethod]
		[WebMethod(EnableSession = true)]
		public bool AddApplyItem(ApplyitemBO applyitemBo)
		{
			//新增主键为0
			if (applyitemBo.ItemId.HasValue) return false;
			return iservice.AddApplyitem(applyitemBo);
		}
		/// <summary>
		///更新
		/// </summary>
		/// <param name="applyitemBo"></param>
		/// <returns></returns>
		[ScriptMethod]
		[WebMethod(EnableSession = true)]
		public bool UpdateApplyItem(ApplyitemBO applyitemBo)
		{
			//要更改实体的主键不能为0
			if (!applyitemBo.ItemId.HasValue) return false;
			return iservice.UpdateApplyitem(applyitemBo);
		}

		/// <summary>
		/// 删除和批量删除
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		[ScriptMethod]
		public bool DeleteApplyItemsByIds(string ids)
		{
			if(string.IsNullOrEmpty(ids))
			{
				return false;
			}
			var tempIds=ids.Split(',').Select(Int32.Parse).ToArray();
			return iservice.DeleteApplyitemByIds(tempIds);
		}

		/// <summary>
		/// 单个查找
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		[ScriptMethod]
		public ApplyitemBO GetApplyitemBoById(Int32 id)
		{
			if(id==0)
			{
				return  null;
			}
			return iservice.GetApplyitemById(id);
		}


		/// <summary>
		/// 报销项目名称唯一性检查
		/// 如果为true，则该名称已经存在
		/// false不存在
		/// </summary>
		/// <param name="itemName"></param>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		[ScriptMethod]
		public bool CheckUniqueApplyItemName(string itemName)
		{
			if(string.IsNullOrEmpty(itemName))
			{
				return true;
			}
			return iservice.CheckUniqueApplyitemName(itemName);
		}

		/// <summary>
		/// 获取所有的报销项目名称和报销项目id
		/// add by ys on 2013-12-06
		/// </summary>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public object GetAllApplyItemNameAndIds()
		{
			var tempDatas = iservice.GetAllApplyItems().Select(p => new CommonModel
				                                                            {
					                                                            Id = p.ItemId.GetValueOrDefault(),
																					Name = p.ItemName,
				                                                            }).ToList();
			return tempDatas ;
		}
	}
}
