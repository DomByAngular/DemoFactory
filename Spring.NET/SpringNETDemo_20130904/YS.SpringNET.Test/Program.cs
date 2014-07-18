using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Spring.Context;
using YS.SpringNET.IService;
using YS.SpringNET.Test.Common;

namespace YS.SpringNET.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 示例1:无Spring工厂实现实例注入

        /*IApplicationContext context = ConfigurationManager.GetSection("spring/context")
                                    as IApplicationContext;
            if(context!=null)
            {
                IPersonService personService= context.GetObject("PersonService") as IPersonService;
                string temp = personService.GetPerson();
                Console.WriteLine(temp);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Spring创建实例失败");
                Console.ReadKey();
            }*/

            #endregion

            var iservice=SpringFactory.GetObject("PersonService") as IPersonService;
            if(iservice!=null)
            {
                var personInfo=iservice.GetPerson();
                Console.WriteLine(personInfo);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("SpringFactory注入实例失败");
                Console.ReadKey();
            }
            
        }
    }
}
