using System;

namespace Infrastructure.Common
{
    public interface IEntity<TIdType>
    {
        TIdType DatabaseId { get; }

        Guid Guid { get; }
    }
}