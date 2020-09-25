using Edu.Entity;
using Edu.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Edu.Repository
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> Query
        {
            get { return context.Set<TEntity>(); }
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void Delete(IList<TEntity> entityList)
        {
            foreach (var entity in entityList)
            {
                context.Set<TEntity>().Remove(entity);
            }
        }

        public virtual List<TEntity> FetchAll()
        {
            return Query.ToList();
        }

        public virtual List<TEntity> FetchAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Query
                .Where(predicate)
                .ToList();
        }

        public virtual PagedResult<TEntity> GetPaged(int page, int pageSize)
        {
            return Query.GetPaged(page, pageSize);
        }

        public virtual PagedResult<TEntity> GetPaged(Expression<Func<TEntity, bool>> predicate, int page, int pageSize)
        {
            return Query.Where(predicate).GetPaged(page, pageSize);
        }

        public virtual PagedResult<TEntity> GetPagedOrderByDescending(Expression<Func<TEntity, bool>> query, Expression<Func<TEntity, object>> ordenExpression, int page, int pageSize)
        {
            return Query.Where(query).OrderByDescending(ordenExpression).GetPaged(page, pageSize);
        }

        public virtual TEntity Find(int id)
        {
            return context.Set<TEntity>()
                .Find(id);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>()
                .Where(predicate)
                .FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> FindMatchesId(IEnumerable<int> keys)
        {
            return context.Set<TEntity>()
               .Where(x => keys.Contains(x.Id))
               .AsEnumerable();
        }
    }
}
