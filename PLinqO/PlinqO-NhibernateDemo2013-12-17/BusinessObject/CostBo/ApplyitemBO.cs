using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace BusinessObject.CostBo
{
	/**************************************************

      ** 作者： 杨双

      ** 创始时间：2013-11-29

      ** 修改人：

      ** 修改时间：

      ** 修改人：

      ** 修改时间：

      ** 描述：

      ** 报销项目业务实体bo，
      
  *****************************************************/
	public class ApplyitemBO
	{
		/*实体字段*/
		public Int32? ItemId { get; set; }
		public string ItemName { get; set; }
		[ScriptIgnore]
		public DateTime? CreatedOn { get; set; }
		public string CreatedBy { get; set; }
		[ScriptIgnore]
		public DateTime? ModifiedOn { get; set; }
		public string ModifiedBy { get; set; }
		[ScriptIgnore]
		public List<ApplydetailBO> ApplydetailListBOs { get; set; }

		/*辅助字段*/
		public string CreatedOnDateStr
		{
			get { return CreatedOn == null ? "" : CreatedOn.GetValueOrDefault().ToString("yyyy-MM-dd"); }
		}
		public string ModifiedOnDateStr
		{
			get { return ModifiedOn == null ? "" : ModifiedOn.GetValueOrDefault().ToString("yyyy-MM-dd"); }
		}
		public string CreatedOnDateLongStr
		{
			get { return CreatedOn == null ? "" : CreatedOn.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss"); }
		}
		public string ModifiedOnDateLongStr
		{
			get { return ModifiedOn == null ? "" : ModifiedOn.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss"); }
		}

		//报销部门
		public string DepartName { get; set; }
	}
}
