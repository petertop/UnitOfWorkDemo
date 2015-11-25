using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data.Abstract;
using UnitOfWorkDemo.Entities;

namespace UnitOfWorkDemo.Data
{
    public class InMemoryDataRepository : IPearsonRepository
    {
        // Fields
        private bool disposedValue = false; // To detect redundant calls
        List<Pearson> _repository;


        // Constructor
        public InMemoryDataRepository()
        {
            _repository = new List<Pearson>();
        }

        public bool Create(Pearson item)
        {
            try
            {
                _repository.Add(item);
                return true;
            }
            catch (Exception ex)
            {
                //ToDo Log error
                return false;
            }

        }

        public bool Update(Pearson item)
        {
            try
            {
                //Find item and remove
                Pearson remove =_repository.Find(p => p.Id == item.Id);
                _repository.Remove(remove);
                // Add new
                _repository.Add(item);
                return true;
            }
            catch (Exception ex)
            {
                //ToDo Log error
                return false;
            }
        }

        public bool Delete(int index)
        {
            try
            {
                //Find item and remove
                Pearson remove = _repository.Find(p => p.Id == index);
                _repository.Remove(remove);
                return true;
            }
            catch (Exception ex)
            {
                //ToDo Log error
                return false;
            }
        }

        public IEnumerable<Pearson> Get()
        {
            try
            {
                return _repository.ToList();
            }
            catch (Exception ex)
            {
                return null;
                //ToDo Log error
            }
        }

        public Pearson GetByIndex(int index)
        {
            try
            {
                //Find item and remove
                Pearson find = _repository.Find(p => p.Id == index);
                return find;

            }
            catch (Exception ex)
            {
                //ToDo Log error
                return null;
            }
        }

        public bool Save()
        {
            // Nothing to do, it is inmemory
            return true;
        }

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _repository = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~InMemoryDataRepository() {
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
