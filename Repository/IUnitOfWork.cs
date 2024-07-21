namespace DoorsSecurity.Repository
{
    public interface IUnitOfWork
    {
        IDoorRepository Door { get; }
        ICardRepository Card { get; }

        Task SaveAsync();
    }
}