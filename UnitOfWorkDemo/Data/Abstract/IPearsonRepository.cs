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
        
        /// <summary>
        /// Get object
        /// </summary>
        /// <returns></returns>
        IEnumerable<Pearson> Get();


        Pearson GetByIndex(int index);


        /// <summary>
        /// Implement save procedure
        /// </summary>
        /// <returns></returns>
        bool Save();
    }
}
