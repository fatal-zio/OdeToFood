using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core.Entities;

namespace OdeToFood.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly OdeToFoodDbContext _context;

        public RestaurantRepository(OdeToFoodDbContext context) => _context = context;

        public IEnumerable<Restaurant> GetRestaurants() => _context.Restaurants.ToList().OrderBy(o => o.Name);

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in _context.Restaurants
                where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                orderby r.Name
                select r;
        }

        public Restaurant GetRestaurant(int id) => _context.Restaurants.FirstOrDefault(o => o.Id == id);

        public void Add(Restaurant restaurant) => _context.Restaurants.Add(restaurant);

        public void Update(Restaurant restaurant) => _context.Restaurants.Update(restaurant);

        public void Delete(Restaurant restaurant) => _context.Restaurants.Remove(restaurant);

        public bool Commit() => _context.SaveChanges() >= 0;
    }
}
