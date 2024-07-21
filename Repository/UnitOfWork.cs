
using DoorsSecurity.Data;

namespace DoorsSecurity.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _db;

        public IDoorRepository Door { get; private set; }

        public UnitOfWork(AppDBContext appDB)
        {
            _db = appDB;
            Door = new DoorRepository(_db);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}