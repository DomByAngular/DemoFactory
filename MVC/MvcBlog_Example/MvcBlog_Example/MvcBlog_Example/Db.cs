using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBlog_Example
{
    public class Db
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        public static List<string> AllBlogUesr
        {
            get
            {
                List<string> userList = new List<string>()
                {
                    "dotNetDR_",
                    "User1",
                    "User2",
                    "User3",
                    "User4",
                    "User5"
                };

                return userList;
            }
        }
    }
}