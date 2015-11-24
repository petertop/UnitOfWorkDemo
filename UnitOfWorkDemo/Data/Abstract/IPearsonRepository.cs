using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Entities;

namespace UnitOfWorkDemo.Data.Abstract
{
    public interface IPearsonRepository : IDisposable
    {
        bool Create(Pearson item);
        bool Update(Pearson item);
        bool Delete(int index);
        IEnumerable<Pearson> Get();
        Pearson GetByIndex(int index);
        bool Save();
    }
}
