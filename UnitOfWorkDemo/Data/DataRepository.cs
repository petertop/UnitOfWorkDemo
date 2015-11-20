using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Entities;

namespace UnitOfWorkDemo.Data
{
    public class DataRepository : IDataRepository
    {
        List<Pearson> _repository;

        public DataRepository()
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
    }
}
