﻿using NHibernate;
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
        ISessionFactory _sessionFactory = NHibernateFactory.CreateSessionFactory();
        ISession _session;
        ITransaction _transaction;

        private bool _disposed = false;

        public UnitOfWorkNhibernate()
        {
            _session = _sessionFactory.OpenSession();
            _repository = new NHibernateLighDataRepository(_session);
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
                throw;
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

                    _sessionFactory.Dispose();

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