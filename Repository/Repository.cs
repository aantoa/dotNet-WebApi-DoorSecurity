
using DoorsSecurity.Data;
using Microsoft.EntityFrameworkCore;

namespace DoorsSecurity.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext _db;
        internal DbSet<T> dbSet;

        public Repository(AppDBContext appDB)
        {
            _db = appDB;
            this.dbSet = _db.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
    }
}