using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core.Entities;
using OdeToFood.Data.Repositories;

namespace OdeToFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantsController(IRestaurantRepository restaurantRepository) => _restaurantRepository = restaurantRepository;

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _restaurantRepository.GetRestaurantsAsync();

            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            if (!await _restaurantRepository.RestaurantExistsAsync(id))
            {
                return NotFound();
            }

            _restaurantRepository.Update(restaurant);

            var result = await _restaurantRepository.CommitAsync();
            return result ? NoContent() : throw new ApplicationException("Error saving restaurant.");
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.Add(restaurant);
            await _restaurantRepository.CommitAsync();

            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantRepository.Delete(restaurant);
            await _restaurantRepository.CommitAsync();

            return NoContent();
        }
    }
}
