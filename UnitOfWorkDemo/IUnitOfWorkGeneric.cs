using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Entities;

namespace UnitOfWorkDemo
{
    public interface IUnitOfWorkGeneric : IDisposable
    {
        void BeginTransaction();
        void Commit();
        RepositoryGeneric<Pearson> PearsonRepository { get; }
        RepositoryGeneric<Order> OrderRepository { get; }
        RepositoryGeneric<Log> LogRepository { get; }
    }
}
