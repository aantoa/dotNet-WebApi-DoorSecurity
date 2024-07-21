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
                var doors = await _doorsService.GetAllDoorsAsync();
                return Ok(doors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetchings doors: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var door = await _doorsService.GetDoorByIdAsync(id);
                return Ok(door);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error fetchings doors: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DoorSaveDto doorSaveDto)
        {
            try
            {
                var door = await _doorsService.AddDoorAsync(doorSaveDto);
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
                var deleted = await _doorsService.RemoveDoorById(id);
                if(deleted)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting doors: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DoorSaveDto doorSaveDto)
        {
            try{
                var door = await _doorsService.UpdateDoorAsync(id, doorSaveDto);
                if(door == null)
                {
                    return NotFound();
                }
                return Ok(door);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error updating doors: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}