using System;
using System.Collections.Generic;
using System.Linq;


namespace WpfLearn.Server
{
    public class Repository<T> where T : DomainObject
    {
        protected readonly UnitOfWork _unitOfWork;


        public Repository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public T GetById(int id)
        {
            return _unitOfWork.Get<T>(id);
        }


        public void Save(T entity)
        {
            _unitOfWork.SaveOrUpdate(entity);
        }


        public void Delete(T entity)
        {
            _unitOfWork.Delete(entity);
        }


        public void Delete(int id)
        {
            _unitOfWork.Delete(_unitOfWork.Get<T>(id));
        }


        public IEnumerable<T> GetList(int page, int pageSize)
        {
            return _unitOfWork.Query<T>()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToArray();
        }
    }
}
