using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data.Abstract;

namespace UnitOfWorkDemo.Data
{
    public static class GenericSessionFactory<T>
    {
        public static ISessionFactory CreateSessionFactory()
        {
            ISessionFactory isessionFactory = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012
                 .ConnectionString(ConfigurationSettings.AppSettings.Get("NHibCnnString")))
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>())
                 .BuildSessionFactory();

            return isessionFactory;
        }
    }
}
