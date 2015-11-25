using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data.Abstract;
using UnitOfWorkDemo.Entities;

namespace UnitOfWorkDemo.Data
{
    public class NHibernateLighDataRepository : IPearsonRepository
    {
        // Fields
        private bool disposedValue = false; // To detect redundant calls
        ISession _session;


        public NHibernateLighDataRepository(ISession session)
        {
            _session = session;
        }


        bool IPearsonRepository.Create(Pearson item)
        {
            try
            {
                _session.Save(item);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

        }


        bool IPearsonRepository.Delete(int index)
        {
            try
            {
                IQuery query = _session.CreateQuery("FROM Pearson WHERE Id = '" + index + "'");

                Pearson item = query.List<Pearson>()[0];

                _session.Delete(item); //delete the record 

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }


        IEnumerable<Pearson> IPearsonRepository.Get()
        {
            try
            {
                string h_stmt = "FROM Pearson";

                IQuery query = _session.CreateQuery(h_stmt);

                IList<Pearson> pearsonList = query.List<Pearson>();

                return pearsonList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        Pearson IPearsonRepository.GetByIndex(int index)
        {
            try
            {
                IQuery query = _session.CreateQuery("FROM Pearson WHERE Id = '" + index + "'");

                Pearson item = query.List<Pearson>()[0];

                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        bool IPearsonRepository.Save()
        {
            return true;
        }

        bool IPearsonRepository.Update(Pearson item)
        {
            try
            {
                //IQuery query = session.CreateQuery("FROM Pearson WHERE Id = '" + item.Id.ToString() + "'");

                //Pearson oldItem = query.List<Pearson>()[0];

                //oldItem.LastName = item.LastName;
                //oldItem.FirstName = item.FirstName;

                _session.Update(item); //delete the record 

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~NHibernateDataRepository() {
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
