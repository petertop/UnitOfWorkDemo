using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data.Abstract;

// Reference 
// http://jasonwatmore.com/post/2015/01/28/Unit-of-Work-Repository-Pattern-in-MVC5-with-Fluent-NHibernate-and-Ninject.aspx
// http://www.codeproject.com/Articles/380022/Simplify-Database-Operations-with-Generic-Fluent-N

namespace UnitOfWorkDemo.Data
{
    public class RepositoryGeneric<T> : IDisposable, IRepository<T> where T : class
    {
        // Fields
        private bool disposedValue = false; // To detect redundant calls
        private ISession _session;


        public RepositoryGeneric(ISession session)
        {
            _session = session;
        }

        public void Create(T entity)
        {
            try
            {
                _session.Save(entity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _session.Delete(_session.Load<T>(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetAll()
        {
            return _session.Query<T>();
        }

        public T GetById(int id)
        {
            return _session.Get<T>(id);
        }

        public void Update(T entity)
        {
            try
            {
                _session.Update(entity); //delete the record 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Repository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
