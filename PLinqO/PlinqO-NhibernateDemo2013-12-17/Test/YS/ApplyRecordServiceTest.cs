using System;
using System.Collections.Generic;
using BusinessObject.CostBo;
using NUnit.Framework;
using Service.Cost.ReimbursementControl;

namespace Test.YS
{
	/***********************************************

	** 作者： 杨双

	** 创始时间：2013-12-03

	** 修改人：

	** 修改时间：

	** 修改人：

	** 修改时间：

	** 描述：

	** 定义成本管理中报销记录服务 单元测试文件
      
	**************************************************/
	public class ApplyRecordServiceTest
	{
		private ApplyRecordService iService = null;
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			//生成日志文件
			var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
					   "\\config\\log4net_local.config";
			var fi = new System.IO.FileInfo(path);
			log4net.Config.XmlConfigurator.Configure(fi);
			iService = new ApplyRecordService();
			//初始化NH profile，检测NH生成的sql
			HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
		}

		[SetUp]
		public void SetUp()
		{
			System.Console.WriteLine("测试启动");
		}

		[TearDown]
		public void TearDown()
		{
			System.Console.WriteLine("测试结束");
		}

		[Test]
		public void AddRecordTest()
		{
			ApplyRecordBO bo = new ApplyRecordBO();
			bo.OrId = 1;
			bo.OrName = "测试部门";
			bo.ApplyBy = "杨双";
			bo.ApplyOn = DateTime.Now;
			bo.AuditStatus = 0;
			bo.CarNo = "31234234";
			bo.Currency = "RMB";
			bo.DepAuditBy = "张三";
			bo.FinanceAuditBy = "李四";
			bo.FinalAuditBy = "王武";
			bo.IsCar = 1;
			bo.Description = "！@@@￥@";
			bo.Price = 1200000f;
			bo.CreatedOn = DateTime.Now;
			bo.CreatedBy = "测试人";
			bool result = iService.AddApplyRecord(bo);
			Assert.AreEqual(true, result);
		}

		[Test]
		public void UpdateApplyRecordTest()
		{
			ApplyRecordBO bo = new ApplyRecordBO();
			bo.ApplyId = 63;
			bo.DepAuditBy = "部门审核通过";
			bo.FinanceAuditBy = "财务审核通过";
			bo.FinalAuditBy = "最终审核通过";
			bo.AuditStatus = 0;
			bo.ModifiedOn = DateTime.Now;
			bo.ModifiedBy = "更新测试人";
			bo.ApplydetailBoList=new List<ApplydetailBO>()
				                     {
					                     new ApplydetailBO(){DetailId = 28,ItemId = 63,Count = 2,Price = 1},
										 new ApplydetailBO(){DetailId = 29,ItemId = 63,Count = 2,Price = 2},
										 new ApplydetailBO(){DetailId = 30,ItemId = 63,Count = 2,Price = 3},
				                     };
			bool result = iService.UpdateApplyRecord(bo);
			Assert.AreEqual(true, result);
		}

		[Test]
		public void GetApplyRecordByIdTest()
		{
			var bo = iService.GetApplyRecordById(1);
			Assert.AreNotEqual(null, bo);
		}

		[Test]
		public void DeleteApplyRecordByIdsTest()
		{
			Int32[] ids = new int[] { 2, 3 };
			var result = iService.DeleteApplyRecordByIds(ids);
			Assert.AreEqual(true, result);
		}

		[Test]
		public void GetApplyRecordsTest()
		{
			ApplyRecordBO bo = new ApplyRecordBO();
			var result = iService.GetApplyRecords(1, 10, "desc", "", bo);
			Assert.AreNotEqual(0, result.ListT.Count);
		}

		/// <summary>
		/// 存储过程使用示例，
		/// add by ys on 2013-12-15
		/// </summary>
		[Test]
		public void CallingProcedureTest()
		{
			int orId = 1;
			var tempDatas=iService.GetApplyRecordBosByCallProcedures(1);
			Assert.AreNotEqual(0,tempDatas.Count);
		}

		/// <summary>
		/// 视图使用示例，
		/// add by ys on 2013-12-15
		/// </summary>
		[Test]
		public void CallingViewTest()
		{
			var tempDatas = iService.GetApplyRecordBosByCallView();
			Assert.AreNotEqual(0, tempDatas.Count);
		}
	}
}
