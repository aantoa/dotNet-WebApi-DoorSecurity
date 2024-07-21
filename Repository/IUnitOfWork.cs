namespace DoorsSecurity.Repository
{
    public interface IUnitOfWork
    {
        IDoorRepository Door { get; }

        Task SaveAsync();
    }
}