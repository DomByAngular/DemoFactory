using System;
using System.Collections;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;

namespace YS.Service.CommomService
{
    /*******************************
     * 
     * 创建Session管理仓库
     * 
     * 提供ISession的管理
     * 
     * 创建人:杨双
     * 
     * 创建时间2013-5-6
     * 
     */
    public sealed  class SessionRepository
    {
        //仓库中的Session工厂
        //活动Session私有，只能由SessionFactory去管理
        private static ISessionFactory sessionFactory;
        private ISession activeSession;


        #region 属性定义
        //当前活动的session
        public ISession ActiveSession
        {
            get
            {
                if (!activeSession.IsOpen)
                {
                    return this.activeSession = sessionFactory.OpenSession();
                }
                else
                {
                    return this.activeSession;
                }
            }
        }

        #endregion
       
        //实现Session工厂的单例模式
        static SessionRepository()
        {
            //写法2:文件路径配置方式，测试通过
           string xmlConfig = AppDomain.CurrentDomain.BaseDirectory+"\\hibernate.cfg.xml";
           sessionFactory = new Configuration().Configure(xmlConfig).BuildSessionFactory();
            
            //写法1：采用web.config配置方式，发布测试和本地测试通过
            //sessionFactory = new Configuration().Configure().AddAssembly("YS.Data").BuildSessionFactory();

            //写法3，文件作为嵌入资源编译进bin，测试通过
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        //私有构造函数禁止外界实例化
//        private SessionRepository()
//        {
//
//        }

        #region 仓库的构造方法
        //创建一个仓库，默认不打开
        public SessionRepository():this(false)
        {

        }

        //创建session仓库，默认打开一个session
        public SessionRepository(bool isOpenSession)
        {
            
            if(isOpenSession)
            {
                //本处可以考虑使用反射创建实例
                activeSession=sessionFactory.OpenSession();
            }
        }

        #endregion

        //打开Session
        public void OpenSession()
        {
            //如果活动session为空，或者活动session已经关闭
            //则打开一个活动session
            if(activeSession==null||!this.ActiveSession.IsOpen)
            {
                this.activeSession = sessionFactory.OpenSession();
            }
            else
            {
                //当前活动的Session已经打开
            }
        }

      /// <summary>
       ///Session的Flush操作
        ///数据提交到数据库
      /// </summary>
        public void FlushSession()
        {
            if(this.activeSession!=null&&this.activeSession.IsOpen)
            {
                //活动session不为空并且处于打开的状态
                this.activeSession.Flush();
            }
        }

        /// <summary>
        /// 关闭Session
        /// </summary>
        public void CloseSession()
        {
            if (this.activeSession != null && this.activeSession.IsOpen)
            {
                this.activeSession.Close();
            }
        }

        #region 仓库对外暴露一些一般处理方法，可以直接来处理和对象有关的操作

        /// <summary>
        /// 通过主键从Sesion中获取单个对象
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetObjectById(Type type, int id)
        {
            if (this.activeSession != null)
            {
                return this.activeSession.Load(type, id);
            }
            else
            {
                throw new NullReferenceException("Session仓库中无活动Session，请打开一个Session链接");
            }
        }

        /// <summary>
        /// 通过类型获取该类型的所有对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList GetAll(Type type)
        {
            return GetAll(type, null);
        }

        /// <summary>
        /// 通过类型获取所有该类型的对象，并且可以指定一个或者多个排序字段
        /// 默认是升序
        /// 返回排序好的对象集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sortProperties"></param>
        /// <remarks>构建一个具体的查询方法，那么order应该由参数传入</remarks>
        /// <returns></returns>
        public IList GetAll(Type type, params string[] sortProperties)
        {
            ICriteria crit = this.activeSession.CreateCriteria(type);
            if (sortProperties != null)
            {
                foreach (string sortProperty in sortProperties)
                {
                    crit.AddOrder(Order.Asc(sortProperty));
                }
            }
            return crit.List();
        }

        /// <summary>
        /// 插入一个对象
        /// </summary>
        /// <param name="obj"></param>
        public void SaveObject(object obj)
        {
            ITransaction trn = this.activeSession.BeginTransaction();
            try
            {
                //先查找对象的更新时间戳，如果有，那么，将当前时间赋值给该时间戳
                //填入更新时间
                PropertyInfo pi = obj.GetType().GetProperty("UpdateTimestamp");
                if (pi != null)
                {
                    pi.SetValue(obj, DateTime.Now, null);
                }
                this.activeSession.Save(obj);
                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// 更新一个对象
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateObject(object obj)
        {
            ITransaction trn = this.activeSession.BeginTransaction();
            try
            {
                this.activeSession.Update(obj);
                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// 删除一个对象，
        /// 可以在mapping映射文件中设置是否级联删除，默认值是？？
        /// </summary>
        /// <param name="obj"></param>
        public void DeleteObject(object obj)
        {
            ITransaction trn = this.activeSession.BeginTransaction();
            try
            {
                this.activeSession.Delete(obj);
                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// 将一个可能被回收的的对象附加到Session，纳入Session 的管理，这样Session对其持有引用
        /// 该对象就不会被gc回收
        /// 这种处理办法是需要的，当对象缓存到asp.net缓存中的时候，并且他们包含了延迟加载的对象
        /// </summary>
        /// <param name="obj"></param>
        public void AttachObjectToCurrentSession(object obj)
        {
            if (this.activeSession != null)
            {
                if (this.activeSession.IsOpen)
                {
                    this.activeSession.Update(obj);
                }
                else
                {
                    throw new InvalidOperationException("当期的Session未打开，附加对象失败.");
                }
            }
            else
            {
                throw new NullReferenceException("无活动的Session，请创建活动的Session对象.");
            }
        }

        /// <summary>
        /// 删除一个对象，将对象标识为要删除，本操作，在session执行flush操作的时候
        /// 会向数据库发出删除语句
        /// 执行删除操作
        /// </summary>
        /// <param name="obj"></param>
        public void MarkForDeletion(object obj)
        {
            this.activeSession.Delete(obj);
        }
        #endregion
    }
}
