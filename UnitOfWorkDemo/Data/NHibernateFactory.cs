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
using UnitOfWorkDemo.Entities;

namespace UnitOfWorkDemo.Data
{
    public class NHibernateFactory: INHibernateSessionFactory
    {
        public ISessionFactory CreateSessionFactory()
        {
            ISessionFactory isessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(ConfigurationSettings.AppSettings.Get("NHibCnnString")))
                .Mappings(m => m
                .FluentMappings.AddFromAssemblyOf<Pearson>())
                .BuildSessionFactory();

            return isessionFactory;
        }
    }

}
