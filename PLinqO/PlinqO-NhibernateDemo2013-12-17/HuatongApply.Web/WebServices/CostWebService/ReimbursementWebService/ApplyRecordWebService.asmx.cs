using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using BusinessObject.CostBo;
using Domain.common;
using Service.Cost.ReimbursementControl;

namespace HuaTongSystem.WebServices.CostWebService.ReimbursementWebService
{
	/********************************************************************************

      ** 作者： 杨双

      ** 创始时间：2013-12-03

      ** 修改人：

      ** 修改时间：

      ** 修改人：

      ** 修改时间：

      ** 描述：

      ** 定义成本管理模块->报销管理->报销记录后台服务文件
      
  *************************************************************************************/
	/// <summary>
	/// ApplyRecordWebService 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
	 [System.Web.Script.Services.ScriptService]
	public class ApplyRecordWebService : System.Web.Services.WebService
	{
		private ApplyRecordService iService { get; set; }
		public ApplyRecordWebService()
		{
			iService = new ApplyRecordService();	
		}

		/// <summary>
		/// 获取分页数据
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="order"></param>
		/// <param name="sort"></param>
		/// <param name="applyRecordBo"></param>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		[ScriptMethod]
		public object GetApplyRecords(int pageIndex,int pageSize,string order,string sort,ApplyRecordBO applyRecordBo)
		{
			if((!string.IsNullOrEmpty(applyRecordBo.OrName))&&applyRecordBo.OrName.Contains("%"))
			{
				applyRecordBo.OrName = applyRecordBo.OrName.Replace("%", @"\%");
			}
			if ((!string.IsNullOrEmpty(applyRecordBo.ApplyBy)) && applyRecordBo.ApplyBy.Contains("%"))
			{
				applyRecordBo.ApplyBy = applyRecordBo.ApplyBy.Replace("%", @"\%");
			}
			var pageDatas=iService.GetApplyRecords(pageIndex, pageSize, order, sort, applyRecordBo);
			if(pageDatas==null||pageDatas.ListT==null)
			{
				return new {total = 0, rows = new object[]{}};
			}
			return new {total=pageDatas.TotalCount,rows=pageDatas.ListT};
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="applyRecordBo"></param>
		/// <returns></returns>
		[ScriptMethod]
		[WebMethod(EnableSession = true)]
		public bool AddApplyRecord(ApplyRecordBO applyRecordBo)
		{
			//新增主键为0
			if (applyRecordBo.ApplyId.HasValue) return false;
			return iService.AddApplyRecord(applyRecordBo);
		}
		/// <summary>
		///更新
		/// </summary>
		/// <param name="applyRecordBo"></param>
		/// <returns></returns>
		[ScriptMethod]
		[WebMethod(EnableSession = true)]
		public bool UpdateApplyRecord(ApplyRecordBO applyRecordBo)
		{
			//要更改实体的主键不能为0
			if (!applyRecordBo.ApplyId.HasValue) return false;
			return iService.UpdateApplyRecord(applyRecordBo);
		}

		/// <summary>
		/// 删除和批量删除
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		[ScriptMethod]
		public bool DeleteApplyRecordsByIds(string ids)
		{
			if(string.IsNullOrEmpty(ids))
			{
				return false;
			}
			var tempIds=ids.Split(',').Select(Int32.Parse).ToArray();
			return iService.DeleteApplyRecordByIds(tempIds);
		}

		/// <summary>
		/// 单个查找
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		[ScriptMethod]
		public ApplyRecordBO GetApplyRecordById(Int32? id)
		{
			if(id==0||id==null)
			{
				return  null;
			}
			return iService.GetApplyRecordById(id.GetValueOrDefault());
		}

		/// <summary>
		/// 根据报销项目id获取该报销项目下的报销详情
		/// 获取报销子项
		/// add by ys on 2013-12-04
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[WebMethod(EnableSession = true)]
		[ScriptMethod]
		public object GetApplyDetailsByRecordId(Int32? id)
		{
			if (id == 0 || id == null)
			{
				return null;
			}
			var tempdatas= iService.GetApplyDetailsByRecordId(id.GetValueOrDefault());
			var returndatas= tempdatas.Select(p => new
				                             {
					                             p.DetailId,//报销子项id
					                             ItemId = p.Applyitem==null?-1:p.Applyitem.ItemId ?? -1, //报销项目编号
					                             ItemName=p.Applyitem==null?string.Empty:p.Applyitem.ItemName, //报销项目名称
					                             p.Count, //数量
					                             p.Price, //报销子项单价
					                             TotalPrice = p.Count*p.Price ?? 0.0d, //总价
					                             p.CreatedOnDateStr //填写时间
				                             }).ToList();
			return new {total = returndatas.Count, rows = returndatas};
		}
	}
}
