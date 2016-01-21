using System;

namespace Infrastructure.Common
{
    public interface IEntity<TIdType>
    {
        TIdType DatabaseId { get; set; }

        Guid Guid { get; set; }
    }
}