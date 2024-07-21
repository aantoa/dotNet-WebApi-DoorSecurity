using DoorsSecurity.Data;
using DoorsSecurity.Dto;
using DoorsSecurity.Models;
using DoorsSecurity.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DoorsSecurity.Services
{
    public class DoorsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoorsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Door>> GetAllDoorsAsync()
        {
            return await _unitOfWork.Door.GetAllAsync();
        }

        public async Task<Door?> GetDoorByIdAsync(int id)
        {
            return await _unitOfWork.Door.GetByIdAsync(id);
        }

        public  async Task<Door> AddDoorAsync(DoorSaveDto doorDto)
        {
            Door door = new Door(){
                Number = doorDto.Number,
                Name = doorDto.Name,
                CreatedAt = DateTime.Now,
                Description = ""
            };

            if( door.Number <0 || door.Number>100 )
            {
                throw new Exception("Incorrect door number");
            }

            await _unitOfWork.Door.AddAsync(door);
            await _unitOfWork.SaveAsync();

            return door;
        }

        public async Task<bool> RemoveDoorById(int id)
        {
            var door = await _unitOfWork.Door.GetByIdAsync(id);
            if( door != null)
            {
                _unitOfWork.Door.Remove(door);
                await _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        } 

        public async Task<Door?> UpdateDoorAsync(int id, DoorSaveDto doorSaveDto)
        {
            var door = await _unitOfWork.Door.GetByIdAsync(id);
            if( door != null)
            {
                door.Number = doorSaveDto.Number;               
                door.Name = doorSaveDto.Name;              
                _unitOfWork.Door.Update(door);
                await _unitOfWork.SaveAsync();
            }
            return door;
        }
    }
}