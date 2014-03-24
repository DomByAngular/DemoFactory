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

      ** 报销单记录业务实体bo，
      
  *****************************************************/
	public class ApplyRecordBO
	{
		/*实体字段*/
		/// <summary>
		/// 报销单主键
		/// </summary>
		public Int32? ApplyId { set; get; }
		
		/// <summary>
		/// 报销部门主键
		/// </summary>
		public Int32? OrId { set; get; }

		/// <summary>
		///部门名称
		/// </summary>
		public string OrName { get; set; }

		/// <summary>
		/// 报销金额
		/// </summary>
		public double? Price { set; get; }
		/// <summary>
		/// 报销币种
		/// </summary>
		public string Currency { set; get; }
		/// <summary>
		/// 经手人
		/// </summary>
		public string ApplyBy { get; set; }
		/// <summary>
		/// 报销单填写时间
		/// </summary>
		[ScriptIgnore]
		public DateTime? ApplyOn { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string Description { set; get; }
		/// <summary>
		/// 是否是车辆成本
		/// </summary>
		public Int32? IsCar { set; get; }
		/// <summary>
		/// 车牌号
		/// </summary>
		public string CarNo { get; set; }
		/// <summary>
		/// 报销审核状态
		/// 0新增，1部门审核，2财务审核，3最终审核，4已支付
		/// </summary>
		public Int32? AuditStatus { get; set; }
		/// <summary>
		/// 部门审核人
		/// </summary>
		public string DepAuditBy { set; get; }
		/// <summary>
		/// 财务审核人
		/// </summary>
		public string FinanceAuditBy { set; get; }
		/// <summary>
		/// 最终审核人
		/// </summary>
		public string FinalAuditBy { get; set; }
		[ScriptIgnore]
		public DateTime? CreatedOn { get; set; }
		public string CreatedBy { set; get; }
		[ScriptIgnore]
		public DateTime? ModifiedOn { set; get; }
		public string ModifiedBy { get; set; }
		[ScriptIgnore]
		public List<ApplydetailBO> ApplydetailBoList { get; set; }

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
		}
		public string ModifiedOnDateLongStr
		{
			get { return ModifiedOn == null ? "" : ModifiedOn.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss"); }
		}

		public string IsCarStr { 
			get { return IsCar == 1 ? "是" : "否"; }
		}

		/// <summary>
		/// 报销单填写时间(年月日时分秒)Str
		/// </summary>
		public string ApplyOnLongStr
		{
			get { return ApplyOn == null ? "" : ApplyOn.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss"); }
			set
			{
				DateTime time = DateTime.Now;
				DateTime.TryParse(value,out time);
				this.ApplyOn = time;
			}
		}
		/// <summary>
		/// 报销单填写时间(年月日)Str
		/// </summary>
		public string ApplyOnStr
		{
			get { return ApplyOn == null ? "" : ApplyOn.GetValueOrDefault().ToString("yyyy-MM-dd"); }
			set
			{
				DateTime time = DateTime.Now;
				bool parseResult=DateTime.TryParse(value, out time);
				if(parseResult)
				{
					this.ApplyOn = time;
				}
				else
				{
					this.ApplyOn = DateTime.Now;
				}
			}
		}

		/// <summary>
		///格式化审核状态
		/// </summary>
		public string AuditStatusStr
		{
			get
			{
				var temp = string.Empty;
				switch (AuditStatus)
				{
					case 0:temp="新增";
						break;
					case 1: temp = "部门审核";
						break;
					case 2: temp = "财务审核";
						break;
					case 3: temp = "最终审核";
						break;
					case 4: temp = "完成支付";
						break;
					default:
						temp = "未知状态";
						break;
				}
				return temp;
			}
		}
	}
}
