using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Data.Abstract
{
    public interface INHibernateSessionFactory
    {
        ISessionFactory CreateSessionFactory();
    }
}
