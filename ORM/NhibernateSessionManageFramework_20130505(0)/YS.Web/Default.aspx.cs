using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YS.BO;
using YS.Service.CommomService;
using YS.Service.PersonService;

namespace YS.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = "repositoryKey";
            //去仓库中找到当前的活动Session
            SessionRepository repository=(SessionRepository)HttpContext.Current.Items[key];
           //创建一个服务
            PersonService personService = new PersonService(repository.ActiveSession);
            //单个查找，代码测试通过
            PersonBo personBo=personService.GetPersonById("34d663c35a164799ada03ed8b16f5224");

            //插入数据，代码测试通过，主义name vachar(16),超过长度sql报错
            PersonBo insertBo1=new PersonBo()
                                  {
                                      ID =Guid.NewGuid().ToString(),
                                      Name = "框架搭建数据1",
                                      Sex = "男"
                                  };
            personService.InsertPerson(insertBo1);

            //批量插入,代码测试通过
            PersonBo insertBo2 = new PersonBo()
            {
                ID = Guid.NewGuid().ToString(),
                Name = "框架搭建数据1",
                Sex = "男"
            };

            personService.BatchInsertPerson(new List<PersonBo>()
                                                {
                                                    insertBo1,insertBo2
                                                });
            IList<PersonBo> dataSource=personService.GetAllPersonBySex("男");
            Repeater1.DataSource = dataSource;
            Repeater1.DataBind();
        }
    }
}