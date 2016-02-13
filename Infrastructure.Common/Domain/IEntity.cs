using System;

namespace Infrastructure.Common
{
    public interface IEntity<TIdType>
    {
        TIdType PersistenceId { get; }

        Guid Guid { get; }
    }
}