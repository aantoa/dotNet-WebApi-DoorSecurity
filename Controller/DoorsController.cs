using DoorsSecurity.Dto;
using DoorsSecurity.Models;
using DoorsSecurity.Repository;
using DoorsSecurity.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DoorsSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoorsController : ControllerBase 
    {
        private readonly DoorsService _doorsService;
        public DoorsController(DoorsService doorsService)
        {
            _doorsService = doorsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var doors = await _doorsService.GetAllDoors();
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
                var door = await _doorsService.AddDoor(doorCreateDto);
                return Ok(door);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating doors: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try{
                await _doorsService.RemoveDoorById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting doors: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}