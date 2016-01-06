// ReSharper disable once CheckNamespace
namespace Infrastructure.Common
{
    using Infrastructure.Common.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class RepositoryBase<TEntity, TIdType, TContext>
        : IRepository<TEntity, TIdType>
        where TEntity : EntityBase<TIdType>
        where TContext : DbContext
    {
        protected TContext Context { get; }

        protected RepositoryBase(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Employee Context");
            }
            this.Context = context;
        }

        public void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }

        public virtual TEntity FindById(TIdType id)
        {
            var entity = this.Context.Set<TEntity>().Find(id);

            return entity;
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> results = Queryable.Where(this.Context.Set<TEntity>(), predicate);
            return results;
        }

        public IEnumerable<TEntity> FindAll()
        {
            IEnumerable<TEntity> entities = this.Context.Set<TEntity>();
            return entities;
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}