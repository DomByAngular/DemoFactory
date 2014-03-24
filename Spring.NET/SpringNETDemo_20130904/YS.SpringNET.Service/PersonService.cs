using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YS.SpringNET.IService;
using YS.SpringNET.Model;

namespace YS.SpringNET.Service
{
    public class PersonService:IPersonService
    {
        public string GetPerson()
        {
            Person person=new Person();
            person.Age = 27;
            person.Name = "杨双";
            person.No = 1;
            person.Sex = "男";
            person.Id = Guid.NewGuid();
            return string.Format("编号:{0},姓名:{1}，性别:{2}", person.No, person.Name, person.Sex);
        }
    }
}
