using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data;

namespace UnitOfWorkDemo
{
    public class UnitOfWork : IDisposable
    {
        // Fields
        private IDataRepository _context = StructureMap.ObjectFactory.GetInstance<IDataRepository>();

        DataRepository _pearsonRepository;
        
        private bool _disposed = false;

        // Fields
        public DataRepository PearsonRepository
        {
            get
            {
                if (this._pearsonRepository == null)
                {
                    this._pearsonRepository = (DataRepository)_context;
                }
                return _pearsonRepository;
            }
        }
       


        // Save
        public void Save()
        {
            _context.Save();
        }


        #region Dispose Method
        // Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    //_context.Dispose();
                }
            }
            this._disposed = true;
        }

        // Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
