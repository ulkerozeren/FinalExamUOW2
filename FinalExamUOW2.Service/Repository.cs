using FinalExamUOW2.Data.Contexts;
using FinalExamUOW2.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamUOW2.Service
{
    public class Repository<T, TContext> : IRepository<T> where T : class
                                                         where TContext : DbContext
    {
        private readonly DbSet<T> _repository;
        public Repository(TContext dataContext)
        {
            _repository = dataContext.Set<T>();
        }
        public bool Delete(int id)
        {
            bool result = false;

            T entity = Find(id);
            if (entity != null)
            {
                _repository.Remove(entity);
                result = true;
            }

            return result;
        }

        public T Find(int id)
        {
            return _repository.Find(id);

        }

        public T Insert(T entity)
        {
            _repository.Add(entity);
            return entity;
        }

        public IEnumerable<T> List()
        {
            return _repository.ToList();
        }

        public IQueryable<T> Query()
        {
            return _repository;
        }

        public T Update(T entity)
        {
            _repository.Update(entity);
            return entity;
        }
    }
}
