using System.Data;
using DoorsSecurity.Data;
using DoorsSecurity.Dto;
using DoorsSecurity.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsSecurity.Repository
{
    public class DoorRepository
    {
        private readonly AppDBContext _db;
        public DoorRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Door>> GetAllDoors()
        {
            return await _db.Doors.ToListAsync();
        }

        public  async Task<Door> AddDoor(DoorCreateDto doorDto)
        {
            Door door = new Door(){
                Number = doorDto.Number,
                Name = doorDto.Name,
                CreatedAt = DateTime.Now,
                Description = ""
            };

            if( door.Number <0 || door.Number>100)
            {
                throw new Exception("Incorrect door number");
            }

            await _db.Doors.AddAsync(door);
            await _db.SaveChangesAsync();

            return door;
        }
    }
}