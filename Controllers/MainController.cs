using DogApi.Model.DbContext;
using DogApi.Model.Dto;
using DogApi.Model.Entities;
using DogApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DogApi.Controllers
{
    [ApiController]
    public class MainController : Controller
    {
        private readonly IDogServices _service;

        public MainController(IDogServices service)
        {
            _service = service;
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
            var queriedDogs = await _service.GetQueriedDogsAsync(request);
            if (!queriedDogs.IsSuccess)
            {
                return BadRequest(queriedDogs.ErrorMessage);
            }
            return Ok(queriedDogs.Dogs);
        }
        [HttpPost]
        [Route("dog")]
        public async Task<IActionResult> CreateDog([FromBody] CreateDogRequest dog)
        {
            var createDog = await _service.CreateDogAsync(dog);
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(errorMessages);
            }
            if (!createDog.IsSuccess)
                return BadRequest(createDog.ErrorMessage);
            return Created("/dog", dog);

        }
    }
}
