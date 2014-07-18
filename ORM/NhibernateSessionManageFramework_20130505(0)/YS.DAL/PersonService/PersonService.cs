using System;
using System.Collections.Generic;
using AutoMapper;
using NHibernate;
using NHibernate.Type;
using YS.BO;
using YS.Data.Entities;
using YS.IService.IPersonService;
using YS.Service.CommomService;

namespace YS.Service.PersonService
{
    public class PersonService : IPersonService
    {
        protected ISession Session { get; set; }

        //完成初始化工作
        //构造方法无返回值,囧，经常忘啊
        public PersonService(ISession session)
        {
            Session = session;
         }

        #region IPersonService 成员

        //插入方法
        public void InsertPerson(PersonBo personBo)
        {
            /*.....完成bo到实体的转换*/
            Mapper.CreateMap<PersonBo, Person>();
            Person temp = Mapper.Map<PersonBo, Person>(personBo);
            
            Session.Save(temp);
            Session.Flush();
        }

        //查找方法，返回唯一对象
        public PersonBo GetPersonById(string personId)
        {
            #region 方法1，最简洁，通id直接查找
            Person person=Session.Get<Person>(personId);
            Mapper.CreateMap<Person, PersonBo>();
            return Mapper.Map<Person,PersonBo>(person);

            #endregion


            #region 方法2，CreateSQLQuery，执行原生的sql语句，效率最高，但是拼接sql麻烦

/*
             * 以下方法测试通过
            IList<Person> Persons= Session.CreateSQLQuery("select * from Person  where id=" + "'"+PersonId+"'").AddEntity(typeof (Person)).List<Person>();
            if(Persons.Count==1)
            {
                return Persons.SingleOrDefault();
            }
            else
            {
                return null;
            }*/

            #endregion
        }

        /// <summary>
        /// 条件查询返回多个对象，返回集合类型
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public IList<PersonBo> GetAllPersonBySex(string sex)
        {
            //方法1：使用原生的sql，本方法测试通过，条件拼接，但是有注入危险
            //IList<Person> Persons = Session.CreateSQLQuery("select * from Person  where sex=" + "'" + sex + "'").AddEntity(typeof(Person)).List<Person>();
            //return Persons;

            //方法2：使用HQL，命名参数。本方法测试通过，推荐使用命名参数
            //IList<Person> Persons=Session.CreateQuery("from Person p where p.Sex=:sex").SetAnsiString("sex",sex).List<Person>();
            //使用HQL，位置参数，方法测试通过
            IList<Person>persons=Session.CreateQuery("from Person p where p.Sex=?").SetAnsiString(0, sex).List<Person>();
            Mapper.CreateMap<Person, PersonBo>();
            
            IList<PersonBo> personBos=Mapper.Map<IList<Person>, IList<PersonBo>>(persons);
            //集合映射转换，你懂的
            return personBos;
        }

        //返回所有数据
        public IList<PersonBo> GetAllPerson()
        {
            //方法一：使用原生的sql查询，代码测试通过
            //return Session.CreateSQLQuery("select * from Person ").AddEntity(typeof (Person)).List<Person>();
            
            //方法二：使用Hql查询，代码测试通过
            //通过NHprofiler工具可以查看，使用Hql进行的查询生成的sql代码为
            /*
                 * select Person0_.ID   as ID0_,
                   Person0_.Name as Name0_,
                   Person0_.Sex  as Sex0_
                from   Person Person0_
             */

            IList<Person>lists=Session.CreateQuery("from Person p").List<Person>();
            return null;
        }

        //根究id删除
        public void  DeletePersonById(string PersonId)
        {
           //Session.BeginTransaction();
           //方法1:实体参数删除
            //var tempPerson=Session.Get<Person>(PersonId);
            //Session.Delete(tempPerson);

           //Session.Delete(new Person() {ID = PersonId});此删除方法错误，会提示有相同主键的实体

            //方法2：主键删除，推荐方法，效率最高的,一定要采用Session事务提交,避免服务端发生异常
            //代码测试通过
           /* string deleteHql = "delete Person p where p.ID=:pid";
            IQuery query = Session.CreateQuery(deleteHql);
            query.SetAnsiString("pid", PersonId);
            query.ExecuteUpdate();
            Session.BeginTransaction().Commit();*/

            //方法3：查询删除(多条件查询删除),本代码测试通过
            //删除思想是先通过查询语句查出要删除的对象，再删除
            try
            {
                string hql1 = "from  Person p where p.Name=?or p.Name=? ";
                Object[] values=new object[]{"Nhibernate99037","Nhibernate41659"};
                IType[] types = new IType[] {NHibernateUtil.String, NHibernateUtil.String};
                Session.Delete(hql1, values, types);
                Session.BeginTransaction().Commit();
                Session.Flush();
                //Evict()方法是从缓存中清除对象，数据库一端数据已经删除，但是本地有缓存
                //经过我测试，通过hql删除以后，直接flush，程序不会有问题
                //Session.Save(new Person() {Name = "杨双824"});
                //bool isExist= Session.Contains(new Person() {Name = "杨双824"});
                //Session.Evict(new Person { Name = "Nhibernate99037" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            //以下删除本方法错误，
            //Session.Delete("delete Person p where p.ID=?", PersonId, NHibernateUtil.String);
           //Session.Flush();   
        }

        /// <summary>
        /// 高性能批量删除
        /// </summary>
        /// <param name="ids"></param>
        public bool BatchDeletePersonsById(string[] ids)
        {
            string idsForSql = "(" + IDHelperForBatchDelete.UnionIDToString(ids) + ")";
            ISQLQuery qry = Session.CreateSQLQuery("delete Person  where id in" + idsForSql);
            ITransaction tans = Session.BeginTransaction();
            try
            {
                qry.ExecuteUpdate();
                tans.Commit();
                return true;
            }
            catch (Exception e)
            {
                tans.Rollback();
                return false;
            }
            
        }

        //高性能主键批量删除
        //使用原生的sql批量删除语句
        public void BatchDeletePersonsById(string ids)
        {
            //第二种方法删除
            string ids2 = "(" + ids + ")";
            
        }

        //多条件查询，返回集合类型
        public IList<PersonBo> GetPersonsByMultiConditions(string sex, string name)
        {
            //注意参数变量一定不可以和原始字段一样，否则报缺参数异常

            //写法1：注意此种写法可以返回强类型的集合
            string hql = "from Person p where p.Sex=:a and p.Name=:b";

            //写法2：此种写法不能返回强类型的集合，只能返回Object数组，强类型化方法编译不报错，但是
            //执行报错，hql具有oo的查询能力
            //string hql = "select p.ID,p.Name,p.Sex from Person p where p.Sex=:a and p.Name=:b";

            //写法3：Hql，支持实体类的构造方法传入，当然，这种写法，entity必须显示的写出构造器和默认的空构造函数
            //string hql = "select new Person(p.ID,p.Name,p.Sex) from Person as p where p.Sex=:a and p.Name=:b";
            IQuery query = Session.CreateQuery(hql);
            query = query.SetParameter("a", sex, NHibernateUtil.String);
            query.SetParameter("b", name, NHibernateUtil.String);
            IList<Person> persons = query.List<Person>();
            Mapper.CreateMap<Person, PersonBo>();
            Mapper.Map<List<Person>,List<PersonBo>>((List<Person>)persons);

            return null;
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="personBos"></param>
        public void BatchInsertPerson(List<PersonBo> personBos)
        {
            Mapper.CreateMap<PersonBo, Person>();
            var persons=Mapper.Map<List<PersonBo>, List<Person>>(personBos);
            foreach (var person in persons)
            {
                Session.Save(person);
            }
            Session.Flush();
            
        }

        #endregion
    }
}
