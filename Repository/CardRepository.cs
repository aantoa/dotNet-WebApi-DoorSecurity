using System.Data;
using DoorsSecurity.Data;
using DoorsSecurity.Dto;
using DoorsSecurity.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsSecurity.Repository
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private readonly AppDBContext _db;
        public CardRepository(AppDBContext appDB) : base(appDB)
        {
            _db = appDB;
        }
    }
}