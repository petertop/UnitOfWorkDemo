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
    public class UnitOfWork : IUnitOfWork
    {
        // Fields
        private IPearsonRepository _repository;
        private bool _disposed = false;
        private EnumRepositoryType _repoType;

        [StructureMap.DefaultConstructor]
        public UnitOfWork(IPearsonRepository repo)
        {
            _repository = repo;
        }


        // Fields
        public IPearsonRepository PearsonRepository
        {
            get
            {
                if (_repoType == EnumRepositoryType.InMemory)
                    _repository = ObjectFactory.GetNamedInstance<IPearsonRepository>("InMemoryRepo");
                else if (_repoType == EnumRepositoryType.NHibernate)
                    _repository = ObjectFactory.GetNamedInstance<IPearsonRepository>("NHibRepo");
                return _repository;
            }
        }


        public EnumRepositoryType RepositoryType
        {
            get {
                return _repoType;
            }
            set {
                _repoType = value;
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
