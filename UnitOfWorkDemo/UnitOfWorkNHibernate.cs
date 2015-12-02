using NHibernate;
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
    public class UnitOfWorkNhibernate : IUnitOfWork
    {
        // Fields
        private IPearsonRepository _repository;
        private ISession _session;
        private ITransaction _transaction;
        private EnumRepositoryType _repoType;

        private bool _disposed = false;

        public UnitOfWorkNhibernate(ISession session)
        {
            _session = session;
            // this is not IoC code, it is direct dependency
            _repository = new NHibernateLighDataRepository(_session);

            // this will not work, save is nost commited
            //_repository = ObjectFactory.GetNamedInstance<IPearsonRepository>("NHibRepoLight");
            _transaction = _session.BeginTransaction();
        }


        // Fields
        public IPearsonRepository PearsonRepository
        {
            get
            {
                return _repository;
            }
        }

        public EnumRepositoryType RepositoryType
        {
            get
            {
                return _repoType;
            }
            set
            {
                _repoType = value;
            }
        }


        // Save
        public void Save()
        {
            try
            {
                _repository.Save();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw ex;
            }

        }


        #region Dispose Method
        // Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();

                    _session.Clear();
                    _session.Close();
                    _session.Dispose();

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
