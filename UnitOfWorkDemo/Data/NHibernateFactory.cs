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
using UnitOfWorkDemo.Mappings;

namespace UnitOfWorkDemo.Data
{
    public class NHibernateFactory: INHibernateSessionFactory
    {
        public ISessionFactory CreateSessionFactory()
        {
            return NHibernateStaticFactory.CreateSessionFactory();
        }
    }

}
