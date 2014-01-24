using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using NHibernate;
using NHibernate.Linq;


namespace WpfLearn.Server
{
    public class UnitOfWork : IDisposable
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        private bool _isAlive = true;
        private bool _isDiscarded;


        public UnitOfWork()
        {
            _session = SessionFactory.OpenSession();
            _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
        }


        public void Dispose()
        {
            if (!_isAlive)
                return;

            try
            {
                if (!_isDiscarded)
                    Commit();
            }
            catch
            {
                Discard();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _session.Dispose();
                _isAlive = false;
            }
        }


        internal T Get<T>(int id)
        {
            return _session.Get<T>(id);
        }


        internal T Load<T>(int id)
        {
            return _session.Load<T>(id);
        }


        internal void SaveOrUpdate<T>(T entity)
        {
            _session.SaveOrUpdate(entity);
        }


        internal void Delete<T>(T entity)
        {
            _session.Delete(entity);
        }


        internal IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }


        public void Discard()
        {
            if (!_isAlive)
                return;

            _transaction.Rollback();
            _session.Close();
            _isDiscarded = true;
        }


        private void Commit()
        {
            _transaction.Commit();
            _session.Flush();
            _session.Close();
        }
    }
}
