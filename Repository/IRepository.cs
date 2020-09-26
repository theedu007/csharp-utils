using Edu.Entity;
using Edu.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Edu.Repository
{
    public interface IRepository<TEntity, TContext> 
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        List<TEntity> FetchAll();
        List<TEntity> FetchAll(Expression<Func<TEntity, bool>> predicate);
        public PagedResult<TEntity> GetPaged(int page, int pageSize);
        public PagedResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> predicate,int page, int pageSize);
        public PagedResult<TEntity> GetPagedOrderByDescending(Expression<Func<TEntity, bool>> query, Expression<Func<TEntity, object>> orderExpression, int page, int pageSize);
        IQueryable<TEntity> Query { get; }
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Delete(IList<TEntity> entityList);
        public TEntity Find(int id);
        public TEntity Find(Expression<Func<TEntity, bool>> predicate);
        public IEnumerable<TEntity> FindMatchesId(IEnumerable<int> keys);
    }
}
