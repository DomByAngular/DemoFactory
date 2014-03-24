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
	public class ApplydetailBO
	{
		/*实体字段*/
		public Int32? DetailId { get; set; }
		public Int32? Count { get; set; }
		public Double? Price { get; set; }
		[ScriptIgnore]
		public DateTime? CreatedOn { get; set; }
		public string CreatedBy { get; set; }
		[ScriptIgnore]
		public DateTime? ModifiedOn { get; set; }
		public string ModifiedBy { get; set; }
		/// <summary>
		/// 报销项目实体
		/// </summary>
		public ApplyitemBO Applyitem { get; set; }
		/// <summary>
		/// 报销单实体
		/// </summary>
		public ApplyRecordBO Applyrecord { get; set; }

		/*辅助字段*/
		public string CreatedOnDateStr
		{
			get { return CreatedOn == null ? "" : CreatedOn.GetValueOrDefault().ToString("yyyy-HH-mm"); }
		}
		public string ModifiedOnDateStr
		{
			get { return ModifiedOn == null ? "" : ModifiedOn.GetValueOrDefault().ToString("yyyy-HH-mm"); }
		}
		public string CreatedOnDateLongStr
		{
			get { return CreatedOn == null ? "" : CreatedOn.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss"); }
			set { this.CreatedOn = DateTime.Parse(value); }
		}
		public string ModifiedOnDateLongStr
		{
			get { return ModifiedOn == null ? "" : ModifiedOn.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss"); }
		}

		public string ItemName { get; set; }
		public Int32? ItemId { get; set; }
		public double TotalPrice {get;set;}
	}
}
