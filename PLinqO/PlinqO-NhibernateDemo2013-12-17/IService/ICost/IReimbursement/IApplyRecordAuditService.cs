using System;
using BusinessObject.CostBo;
using Domain.common;

namespace IService.ICost.IReimbursement
{
	/***********************************************

	** 作者： 杨双

	** 创始时间：2013-12-03

	** 修改人：

	** 修改时间：

	** 修改人：

	** 修改时间：

	** 描述：

	** 定义成本管理中报销详情服务接口
      
**************************************************/
	public interface IApplyAuditService
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
		Page<ApplyRecordBO> GetAuditApplyRecords(int pageIndex, int pageSize, string order, string sort, ApplyRecordBO applyRecordBo);

		/// <summary>
		/// 根据报销单的id进行报销状态的审核
		/// 返回审核结果和提示消息
		/// add by ys on 2013-12-12
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		string[] AuditApplyRecordByIds(Int32[] ids);
	}
}
