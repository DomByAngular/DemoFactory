using System;
using System.Web;

namespace YS.Service.CommomService
{
    //定义一个Module，专门用来管理Session
    //module中引用dal，实现对dal实例的管理
    public class NHSessionModule : IHttpModule
    {
        private static readonly string RepositoryKey = "repositoryKey";

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Context_BeginRequest);
            context.EndRequest += new EventHandler(Context_EndRequest);
        }

        public void Dispose()
        {
        }

        //定义默认的构造函数
        public NHSessionModule()
        {
        }

        private void Context_BeginRequest(Object sender, EventArgs e)
        {
            //请求发起的时候，创建仓库
            SessionRepository resSessionRepository = new SessionRepository(true);
            HttpContext.Current.Items.Add(RepositoryKey, resSessionRepository);
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\Config\\log4net_local.config";
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(filePath));
            //破解版中的初始化工作要这么写
            //HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();    
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
        }

        //请求
        private void Context_EndRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Items["CoreRepository"] != null)
            {
                //请求结束以后，关掉链接
                SessionRepository sessionRepository = (SessionRepository) HttpContext.Current.Items[RepositoryKey];
                if (sessionRepository.ActiveSession != null)
                {
                    if (sessionRepository.ActiveSession.Transaction != null &&
                        sessionRepository.ActiveSession.Transaction.IsActive)
                    {
                        sessionRepository.ActiveSession.Transaction.Commit();
                    }
                    sessionRepository.CloseSession();
                }
            }
        }

       
    }
}