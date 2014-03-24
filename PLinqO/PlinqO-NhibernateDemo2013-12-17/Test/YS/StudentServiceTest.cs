using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObject.StuCourseBo;
using NUnit.Framework;
using Service.StuCourse;

namespace Test.YS
{
	class StudentServiceTest
	{
		private StudentService iService = null;
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			//生成日志文件
			var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
					   "\\config\\log4net_local.config";
			var fi = new System.IO.FileInfo(path);
			log4net.Config.XmlConfigurator.Configure(fi);
			iService = new StudentService();
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

		/// <summary>
		/// 多对多关系，数据写入测试
		///  add by ys on 2013-12-15
		/// </summary>
		[Test]
		public void AddStudentTest()
		{
			StudentBo tempBo = new StudentBo();
			tempBo.Name = "张三";
			tempBo.CourseListBos=new List<CourseBo>(){new CourseBo(){Identification = 1},new CourseBo(){Identification = 3}};
			bool temp=iService.AddStudent(tempBo);
			Assert.AreEqual(true,temp);
		}

		/// <summary>
		/// 多对多关系，解除单个关系/解除全部关系的测试
		/// add by ys on 2013-12-15
		/// </summary>
		[Test]
		public void DeleteStudentCouseTest()
		{
			//从id为8的学生选课中，删除id为1的选课
			//8号学生不再选修id=1的课程
			var temp=iService.DeleteStudentCouse(8, 1);
			Assert.AreEqual(true,temp);
		}
	}
}
