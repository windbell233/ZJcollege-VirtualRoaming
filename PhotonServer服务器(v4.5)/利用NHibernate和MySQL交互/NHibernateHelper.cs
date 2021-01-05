using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;//引用NHibernate空间
using NHibernate.Cfg;//引用NHibernate配置

namespace Windbelledu
{
    class NHibernateHelper//帮助类，管理会话工厂
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)//如果为空，说明SessionFactory还未初始化，执行初始化
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly("Windbelledu");//配置路径
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()//给外界提供方法
        {
            return SessionFactory.OpenSession();
        }
    }
}
