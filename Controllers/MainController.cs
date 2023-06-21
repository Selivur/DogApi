using DogApi.Model.DbContext;
using DogApi.Model.Dto;
using DogApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DogApi.Controllers
{
    [ApiController]
    public class MainController : Controller
    {
        private readonly DogContext _context;
        public MainController(DogContext context) 
        {
            _context = context;
        }
        [HttpGet]
        [Route("dogs")]
        public async Task<IActionResult> QueriedDogs([FromQuery] GetQueriedDogsRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(errorMessages);
            }
            return Ok(_context.Dogs);
        }
        [HttpPost]
        [Route("dog")]
        public async Task<IActionResult> CreateDog([FromBody] CreateDogRequest dog)
        {          
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(errorMessages);
            }
            Dog dogs = new Dog
            {
                Name = dog.Name,
                Color = dog.Color,
                TailLength = dog.TailLength,
                Weight = dog.Weight
            };
            _context.Add(dogs);
            _context.SaveChanges();
            return Created("/dog", dog);

        }
    }
}
