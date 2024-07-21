using DoorsSecurity.Data;
using DoorsSecurity.Dto;
using DoorsSecurity.Models;
using DoorsSecurity.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DoorsSecurity.Services
{
    public class CardsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CardsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Card>> GetAllCardsAsync()
        {
            return await _unitOfWork.Card.GetAllAsync();
        }

        public async Task<Card?> GetCardByIdAsync(int id)
        {
            return await _unitOfWork.Card.GetByIdAsync(id);
        }

        public  async Task<Card> AddCardAsync(CardSaveDto cardDto)
        {
            Card card = new Card(){
                Number = cardDto.Number,
                FirstName = cardDto.FirstName,
                LastName = cardDto.LastName,
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now.AddYears(1)                
            };

            await _unitOfWork.Card.AddAsync(card);
            await _unitOfWork.SaveAsync();

            return card;
        }

        public async Task<bool> RemoveCardById(int id)
        {
            var card = await _unitOfWork.Card.GetByIdAsync(id);
            if( card != null)
            {
                _unitOfWork.Card.Remove(card);
                await _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        } 

        public async Task<Card?> UpdateCardAsync(int id, CardSaveDto cardSaveDto)
        {
            var card = await _unitOfWork.Card.GetByIdAsync(id);
            if( card != null)
            {
                card.Number = cardSaveDto.Number;               
                card.FirstName = cardSaveDto.FirstName;      
                card.LastName = cardSaveDto.LastName;           
                _unitOfWork.Card.Update(card);
                await _unitOfWork.SaveAsync();
            }
            return card;
        }
    }
}