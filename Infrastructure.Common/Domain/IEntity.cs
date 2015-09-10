namespace Infrastructure.Common.Domain
{
    public interface IEntity<TIdType>
    {
        TIdType Id { get; set; }
    }
}