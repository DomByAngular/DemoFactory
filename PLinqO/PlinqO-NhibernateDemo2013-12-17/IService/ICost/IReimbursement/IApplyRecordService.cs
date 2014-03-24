using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

	** 定义成本管理中报销记录服务接口
      
**************************************************/
	public interface IApplyRecordService
	{
		/// <summary>
		/// 添加报销记录
		/// add by ys on 2013-12-02
		/// </summary>
		/// <param name="applyRecordBo"></param>
		/// <returns></returns>
		bool AddApplyRecord(ApplyRecordBO applyRecordBo);

		/// <summary>
		/// 更新报销记录
		/// add by ys on 2013-12-03
		/// </summary>
		/// <param name="applyRecordBo"></param>
		/// <returns></returns>
		bool UpdateApplyRecord(ApplyRecordBO applyRecordBo);

		/// <summary>
		/// 根据id删除报销记录
		/// add by ys on 2013-12-03
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		bool DeleteApplyRecordByIds(Int32[] ids);

		/// <summary>
		/// 根据id进行报销记录的查找，
		/// add by ys on 2013-12-03
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		ApplyRecordBO GetApplyRecordById(Int32 id);

		/// <summary>
		/// 报销记录名称唯一性检查，
		/// add by ys on 2013-12-02
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		bool CheckUniqueApplyRecordName(string name);

		/// <summary>
		/// 获取报销记录的分页数据
		/// add by ys on 2013-12-03
		/// </summary>
		/// <param name="pageSize"> </param>
		/// <param name="order"></param>
		/// <param name="sort"></param>
		/// <param name="applyRecordBo"></param>
		/// <param name="pageIndex"> </param>
		/// <returns></returns>
		Page<ApplyRecordBO> GetApplyRecords(int pageIndex, int pageSize, string order, string sort, ApplyRecordBO applyRecordBo);

		/// <summary>
		/// 根据报项项的id获取该报销项目下的报销子项
		/// add by ys on 2013-12-04
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		List<ApplydetailBO> GetApplyDetailsByRecordId(Int32 id);

		/// <summary>
		/// 通过存储过程调用，获取指定部门的所有报销单信息
		/// add by ys on 2013-12-15
		/// </summary>
		/// <param name="orId"></param>
		/// <returns></returns>
		List<ApplyRecordBO> GetApplyRecordBosByCallProcedures(Int32 orId);

		/// <summary>
		/// 通过视图调用，获取指定部门的所有报销单信息
		/// add by ys on 2013-12-15
		/// </summary>
		/// <returns></returns>
		List<ApplyRecordBO> GetApplyRecordBosByCallView();
	}
}
