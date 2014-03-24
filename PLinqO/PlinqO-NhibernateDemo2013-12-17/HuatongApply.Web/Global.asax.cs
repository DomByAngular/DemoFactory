using System;
using System.Web.Configuration;

namespace HuaTongSystem
{
    public class Global : System.Web.HttpApplication
    {

		public Global()
		{
			// 在应用程序启动时运行的代码
			//初始化日志文件 
			var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
						   WebConfigurationManager.AppSettings["log4net"];
			var fi = new System.IO.FileInfo(path);
			log4net.Config.XmlConfigurator.Configure(fi);
		}

		void Application_Start(object sender, EventArgs e)
		{
			//开发期间监测sql语句的打印
			HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
		}

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }

    }
}
