using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Login.DataSet_ProductsTableAdapters;

namespace Login
{
    /// <summary>
    /// GetPrice 的摘要说明
    /// </summary>
    public class GetPrice : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["name"];
            var data=new tb_ProductsTableAdapter().GetDataByName(name);
            if (data.Count <= 0)
            {
                //context.Response.Write("none|0");
                //context.Response.Write("Hello World");
                context.Response.Write("none");
            }

            else
            {
                //context.Response.Write("ok|" + data.Single().Price);
                context.Response.Write("ok");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}