using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo
{
    public interface IUnitOfWorkGeneric
    {
        void BeginTransaction();
        void Commit();
    }
}
