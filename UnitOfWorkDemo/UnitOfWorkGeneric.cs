using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Entities;

// Reference 
// http://jasonwatmore.com/post/2015/01/28/Unit-of-Work-Repository-Pattern-in-MVC5-with-Fluent-NHibernate-and-Ninject.aspx
// http://www.codeproject.com/Articles/380022/Simplify-Database-Operations-with-Generic-Fluent-N

namespace UnitOfWorkDemo
{
    public class UnitOfWorkGeneric : IUnitOfWorkGeneric, IDisposable
    {
        // Fields
        private bool _disposed = false;
        private ISession _session;
        private ITransaction _transaction;
        private RepositoryGeneric<Pearson> _pearsonRepository;
        private RepositoryGeneric<Order> _orderRepository;
        private RepositoryGeneric<Log> _logRepository;


        // Constructor
        public UnitOfWorkGeneric()
        {
            _session = NHibernateStaticFactory.CreateSessionFactory().OpenSession();
            _pearsonRepository = new RepositoryGeneric<Pearson>(_session);
            _orderRepository = new RepositoryGeneric<Order>(_session);
            _logRepository = new RepositoryGeneric<Log>(_session);

            // Always start transaction
            _transaction = Session.BeginTransaction();

        }


        public RepositoryGeneric<Pearson> PearsonRepository
        {
            get
            {
                return _pearsonRepository;
            }
        }


        public RepositoryGeneric<Order> OrderRepository
        {
            get
            {
                return _orderRepository;
            }
        }

        public RepositoryGeneric<Log> LogRepository
        {
            get
            {
                return _logRepository;
            }
        }


        // Properties
        public ISession Session
        {
            get
            {
                return _session;
            }
            private set
            {
                _session = value;
            }
        }


        public void BeginTransaction()
        {
            if (_transaction == null)
                _transaction = Session.BeginTransaction();
        }


        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _session.Clear();
                _session.Close();
            }

        }


        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (_transaction != null && !_transaction.WasCommitted)
                        _transaction.Commit();

                    if (_transaction != null)
                        _transaction.Dispose();

                    _session.Dispose();

                    _pearsonRepository.Dispose();
                    _orderRepository.Dispose();
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
