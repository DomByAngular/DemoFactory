using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Service.Cost.ReimbursementControl;

namespace CYSBasicSystem.Data.YS
{
	/***********************************************

	** 作者： 杨双

	** 创始时间：2013-12-03

	** 修改人：

	** 修改时间：

	** 修改人：

	** 修改时间：

	** 描述：

	** 定义成本管理中报销详情服务 单元测试
      
	**************************************************/
	public class ApplyDetailServiceTest
	{
		private ApplyAuditService iService = null;
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			//生成日志文件
			var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
					   "\\config\\log4net_local.config";
			var fi = new System.IO.FileInfo(path);
			log4net.Config.XmlConfigurator.Configure(fi);
			iService = new ApplyAuditService();
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
	}
}
