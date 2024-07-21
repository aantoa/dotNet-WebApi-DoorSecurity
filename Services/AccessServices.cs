using DoorsSecurity.Data;
using DoorsSecurity.Dto;
using DoorsSecurity.Models;
using DoorsSecurity.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DoorsSecurity.Services
{
    public class AccessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> GrantAccessAsync(int cardId, int doorId)
        {        
            var card = await _unitOfWork.Card.GetByIdAsync(cardId);
            var door = await _unitOfWork.Door.GetByIdAsync(doorId);
            
            if( card != null && door != null )
            {
                Console.WriteLine(card.Doors);
                card.Doors.Add(door);
                await _unitOfWork.SaveAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RevokeAccessAsync(int idCard, int idDoor)
        {
            return true;
        }
    }
}