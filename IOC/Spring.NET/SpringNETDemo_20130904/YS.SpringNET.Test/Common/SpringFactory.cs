using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;

namespace YS.SpringNET.Test.Common
{
    /// <summary>
    /// add by ys on 2013-9-3
    /// 封装spring工厂
    /// </summary>
    public  class SpringFactory
    {
        private SpringFactory()
        {
        }
        private static bool isInit = false;
        private static IApplicationContext context;
        //Spring工厂初始化方法
        public static void Init()
        {
            #region 使用方式2，后台代码初始化IOC容器
            /*string[] xmlFiles = new string[1];
            xmlFiles[0] = AppDomain.CurrentDomain.BaseDirectory + "/Config/SpringServiceConfig.xml";
            context = new XmlApplicationContext(xmlFiles[0]);
             
           // 使用方式1，xml服务配置文件直接放到项目跟目录下
            // context = new XmlApplicationContext("SpringServiceConfig.xml");
             */

            #endregion
            #region 使用方式1，应用程序配置文件来自动加载
            //本IOC初始化方式需要添加Spring.Context.Support.ContextHandler
            context = ContextRegistry.GetContext();
            #endregion
            isInit = true;
        }

        /// <summary>
        /// 获取实例方法
        /// add by ys on 2013-9-3
        /// </summary>
        /// <param name="objectName"></param>
        /// <returns></returns>
        public static Object GetObject(string objectName)
        {
            if(!isInit)
            {
                Init();
            }
            return context.GetObject(objectName);
        }
    }
}
