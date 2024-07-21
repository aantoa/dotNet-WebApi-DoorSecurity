using DoorsSecurity.Dto;
using DoorsSecurity.Models;
using DoorsSecurity.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DoorsSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoorsController : ControllerBase 
    {
        private readonly DoorRepository _doorRepository;
        public DoorsController(DoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var doors = await _doorRepository.GetAllDoors();
                return Ok(doors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetchings doors: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DoorCreateDto doorCreateDto)
        {
            try
            {
                var door = await _doorRepository.AddDoor(doorCreateDto);
                return Ok(door);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating doors: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}