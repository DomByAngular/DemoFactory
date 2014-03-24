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

	** 创始时间：2013-11-29

	** 修改人：

	** 修改时间：

	** 修改人：

	** 修改时间：

	** 描述：

	** 定义成本管理中报销项目服务接口
      
**************************************************/
	public interface IReimbursementService
	{
		/// <summary>
		/// 添加报销项目
		/// add by ys on 2013-11-29
		/// </summary>
		/// <param name="applyitemBo"></param>
		/// <returns></returns>
		bool AddApplyitem(ApplyitemBO applyitemBo);

		/// <summary>
		/// 更新报销项目
		/// add by ys on 2013-11-29
		/// </summary>
		/// <param name="applyitemBo"></param>
		/// <returns></returns>
		bool UpdateApplyitem(ApplyitemBO applyitemBo);

		/// <summary>
		/// 根据id删除报销项目
		 /// add by ys on 2013-11-29
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		bool DeleteApplyitemByIds(Int32[] ids);

		/// <summary>
		/// 根据id进行报销项目的查找，
		 /// add by ys on 2013-11-29
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		ApplyitemBO GetApplyitemById(Int32 id);

		/// <summary>
		/// 报销项目名称唯一性检查，
		/// add by ys on 2013-12-02
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		bool CheckUniqueApplyitemName(string name);

		/// <summary>
		/// 获取报销项目的分页数据
		/// add by ys on 2013-11-29
		/// </summary>
		/// <param name="pageSize"> </param>
		/// <param name="order"></param>
		/// <param name="sort"></param>
		/// <param name="applyitemBo"></param>
		/// <param name="pageIndex"> </param>
		/// <returns></returns>
		Page<ApplyitemBO> GetApplyitems(int pageIndex, int pageSize, string order, string sort, ApplyitemBO applyitemBo);

		/// <summary>
		/// 获取所有申请项目名称和id
		/// add by ys on 2013-12-06
		/// </summary>
		/// <returns></returns>
		List<ApplyitemBO> GetAllApplyItems();
	}
}
