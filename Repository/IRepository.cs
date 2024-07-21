namespace DoorsSecurity.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);

        void Remove(T entity);

        Task<T?> GetByIdAsync(int id);

        void Update(T entity);
    }
}