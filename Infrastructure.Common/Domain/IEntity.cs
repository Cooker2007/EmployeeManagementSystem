namespace Infrastructure.Common
{
    public interface IEntity<TIdType>
    {
        TIdType Id { get; set; }
    }
}