namespace Infrastructure.Common
{
    public interface IRepository<TEntity, TIdType>
       : IReadOnlyRepository<TEntity, TIdType> where TEntity
       : IEntity<TIdType>
    {
        void Remove(TEntity entity);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Save();
    }
}