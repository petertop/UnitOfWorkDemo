using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data.Abstract;

namespace UnitOfWorkDemo
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        IPearsonRepository PearsonRepository { get; }
        EnumRepositoryType RepositoryType { get; set; }
    }
}
