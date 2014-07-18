using System;
using System.Collections.Generic;
using NUnit.Framework;
using YS.BO;
using YS.Service.PersonService;
using YS.Service.CommomService;

namespace YS.Test
{
    public class SampleTest
    {
        private static SessionRepository sessionRepository;
        private PersonService personService;
        [TestFixtureSetUp]
        public void Init()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\Config\\log4net_local.config";
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(filePath));
            //有些破解版中的初始化工作要如下写
            //HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();    
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
//            sample = new NhibernateSample(NhibernateHelper.GetCurrentSession());
            sessionRepository = new SessionRepository();
            sessionRepository.OpenSession();
            personService=new PersonService(sessionRepository.ActiveSession);
        }

        /// <summary>
        /// 条件查询测试
        /// </summary>
        [Test]
        public void GetAllPersonBySexTest()
        {
            bool testResult = false;
            IList<PersonBo>personBos=personService.GetAllPersonBySex("男");

            if(personBos.Count>0)
            {
                testResult = true;
            }
            Assert.AreEqual(true,testResult);
        }

        //高性能批删除测试
        [Test]
        public void BatchDeleteByIds()
        {
            bool testResult = false;
            IList<PersonBo> personBos = personService.GetAllPersonBySex("男");
            string[] ids=new string[personBos.Count];
            for (int i = 0; i < personBos.Count; i++)
            {
                ids[i] = personBos[i].ID;
            }
            testResult=personService.BatchDeletePersonsById(ids);
            Assert.AreEqual(true,testResult);
        }
    }
}
