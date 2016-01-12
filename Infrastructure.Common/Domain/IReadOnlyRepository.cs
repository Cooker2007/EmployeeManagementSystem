using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure.Common
{
    public interface IReadOnlyRepository<TEntity, TIdType>
        where TEntity : IEntity<TIdType>
    {
        TEntity FindById(TIdType id);

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindAll();
    }
}