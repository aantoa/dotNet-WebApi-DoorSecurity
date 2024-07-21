using System.Data;
using DoorsSecurity.Data;
using DoorsSecurity.Dto;
using DoorsSecurity.Models;

namespace DoorsSecurity.Repository
{
    public class DoorRepository
    {
        private readonly AppDBContext _db;
        public DoorRepository(AppDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Door> GetAllDoors()
        {
            return _db.Doors.ToList();
        }

        public Door AddDoor(DoorCreateDto doorDto)
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

            _db.Doors.Add(door);
            _db.SaveChanges();

            return door;
        }
    }
}