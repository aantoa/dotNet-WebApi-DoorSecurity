using System.Data;
using DoorsSecurity.Data;
using DoorsSecurity.Dto;
using DoorsSecurity.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsSecurity.Repository
{
    public class DoorRepository : Repository<Door>, IDoorRepository
    {
        private readonly AppDBContext _db;
        public DoorRepository(AppDBContext appDB) : base(appDB)
        {
            _db = appDB;
        }
    }
}