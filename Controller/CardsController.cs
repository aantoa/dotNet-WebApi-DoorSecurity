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
    public class CardsController : ControllerBase 
    {
        private readonly CardsService _cardsService;
        public CardsController(CardsService cardsService)
        {
            _cardsService = cardsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cards = await _cardsService.GetAllCardsAsync();
                return Ok(cards);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetchings cards: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var card = await _cardsService.GetCardByIdAsync(id);
                return Ok(card);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error fetching card: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CardSaveDto cardSaveDto)
        {
            try
            {
                var card = await _cardsService.AddCardAsync(cardSaveDto);
                return Ok(card);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating card: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try{
                var deleted = await _cardsService.RemoveCardById(id);
                if(deleted)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting card: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CardSaveDto cardSaveDto)
        {
            try{
                var card = await _cardsService.UpdateCardAsync(id, cardSaveDto);
                if(card == null)
                {
                    return NotFound();
                }
                return Ok(card);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error updating card: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}