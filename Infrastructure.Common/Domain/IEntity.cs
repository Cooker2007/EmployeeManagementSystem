using System;

namespace Infrastructure.Common
{
    public interface IEntity<TIdType>
    {
        TIdType Id { get; set; }

        Guid Guid { get; set; }
    }
}