using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Data.Abstract;

namespace UnitOfWorkDemo
{
    public class UnitOfWork : IDisposable
    {
        // Fields
        private IPearsonRepository _repository;

        private IPearsonRepository _nHibernatePearsonRepo = ObjectFactory.GetNamedInstance<IPearsonRepository>("NHibRepo");

        private bool _disposed = false;

        public UnitOfWork(EnumRepositoryType repo)
        {
            if (repo == EnumRepositoryType.InMemory)
                _repository = ObjectFactory.GetNamedInstance<IPearsonRepository>("InMemoryRepo");
            else if (repo == EnumRepositoryType.NHibernate)
                _repository = ObjectFactory.GetNamedInstance<IPearsonRepository>("NHibRepo");
        }


        // Fields
        public IPearsonRepository PearsonRepository
        {
            get
            {
                return _repository;
            }
        }


        // Save
        public void Save()
        {
            _repository.Save();
        }


        #region Dispose Method
        // Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
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
