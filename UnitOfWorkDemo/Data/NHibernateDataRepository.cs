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
    public class NHibernateDataRepository : IPearsonRepository
    {
        // Fields
        private bool disposedValue = false; // To detect redundant calls
        ISessionFactory sessionFactory = NHibernateFactory.CreateSessionFactory();



        bool IPearsonRepository.Create(Pearson item)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(item);

                        transaction.Commit();

                        return true;

                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        return false;
                    }
                }
            }

        }


        bool IPearsonRepository.Delete(int index)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        IQuery query = session.CreateQuery("FROM Pearson WHERE Id = '" + index + "'");

                        Pearson item = query.List<Pearson>()[0];

                        session.Delete(item); //delete the record 

                        transaction.Commit(); //commit it 

                        return true;

                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        return false;
                    }
                }
            }
        }

        IEnumerable<Pearson> IPearsonRepository.Get()
        {
            using (var session = sessionFactory.OpenSession())
            {
                string h_stmt = "FROM Pearson";

                IQuery query = session.CreateQuery(h_stmt);

                IList<Pearson> pearsonList = query.List<Pearson>();

                return pearsonList;
            }
        }

        Pearson IPearsonRepository.GetByIndex(int index)
        {
            using (var session = sessionFactory.OpenSession())
            {
                    try
                    {
                        IQuery query = session.CreateQuery("FROM Pearson WHERE Id = '" + index + "'");

                        Pearson item = query.List<Pearson>()[0];

                        return item;
                    }

                    catch (Exception ex)
                    {
                        return null;
                    }
                
            }
        }

        bool IPearsonRepository.Save()
        {
            return true;
        }

        bool IPearsonRepository.Update(Pearson item)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        //IQuery query = session.CreateQuery("FROM Pearson WHERE Id = '" + item.Id.ToString() + "'");

                        //Pearson oldItem = query.List<Pearson>()[0];

                        //oldItem.LastName = item.LastName;
                        //oldItem.FirstName = item.FirstName;

                        session.Update(item); //delete the record 

                        transaction.Commit(); //commit it 

                        return true;

                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        return false;
                    }
                }
            }
        }

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    sessionFactory.Dispose();
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
