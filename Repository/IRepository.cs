using Edu.Entity;
using Edu.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Edu.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        List<T> FetchAll();
        List<T> FetchAll(Expression<Func<T, bool>> predicate);
        public PagedResult<T> GetPaged(int page, int pageSize);
        public PagedResult<T> GetPaged(Expression<Func<T, bool>> predicate,int page, int pageSize);
        public PagedResult<T> GetPagedOrderByDescending(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderExpression, int page, int pageSize);
        IQueryable<T> Query { get; }
        void Add(T entity);
        void Delete(T entity);
        void Delete(IList<T> entityList);
        public T Find(int id);
        public T Find(Expression<Func<T, bool>> predicate);
        public IEnumerable<T> FindMatchesId(IEnumerable<int> keys);
    }
}
