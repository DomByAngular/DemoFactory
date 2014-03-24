using System.Collections.Generic;
using YS.BO;

namespace YS.IService.IPersonService
{
    public interface IPersonService
    {
        //定义一系列服务接口
        //基本的CRUD
        //批增加批删除等
        //add by ys on 2013-5-6
        void InsertPerson(PersonBo person);
        PersonBo GetPersonById(string personId);
        IList<PersonBo> GetAllPersonBySex(string sex);
        IList<PersonBo> GetAllPerson();
        void DeletePersonById(string personId);
        bool BatchDeletePersonsById(string[] ids);
        IList<PersonBo> GetPersonsByMultiConditions(string sex, string name);
        void BatchInsertPerson(List<PersonBo> personBos);
    }
}
