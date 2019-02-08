using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core.Entities;

namespace OdeToFood.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly OdeToFoodDbContext _context;

        public RestaurantRepository(OdeToFoodDbContext context) => _context = context;

        public IEnumerable<Restaurant> GetRestaurants() => _context.Restaurants.ToList().OrderBy(o => o.Name);
        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync() => await _context.Restaurants.ToListAsync();

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in _context.Restaurants
                where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                orderby r.Name
                select r;
        }

        public Restaurant GetRestaurant(int id) => _context.Restaurants.FirstOrDefault(o => o.Id == id);
        public async Task<Restaurant> GetRestaurantAsync(int id) => 
            await _context.Restaurants.FirstOrDefaultAsync(o => o.Id == id);

        public void Add(Restaurant restaurant) => _context.Restaurants.Add(restaurant);
        public void Update(Restaurant restaurant) => _context.Restaurants.Update(restaurant);
        public void Delete(Restaurant restaurant) => _context.Restaurants.Remove(restaurant);
        public int GetCount() => _context.Restaurants.Count();
        public async Task<bool> RestaurantExistsAsync(int id) => await _context.Restaurants.AnyAsync(o => o.Id == id);
        public bool Commit() => _context.SaveChanges() >= 0;
        public async Task<bool> CommitAsync() => await _context.SaveChangesAsync() >= 0;
    }
}
