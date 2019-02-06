using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;
using OdeToFood.Core.Entities;
using OdeToFood.Core.Enums;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>  
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Joe's Mexican Restaurant", Location = "Texas", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Jeffrey's Lounge", Location = "Manitoba", Cuisine = CuisineType.Comfort },
                new Restaurant { Id = 4, Name = "Clay Oven", Location = "Manitoba", Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in _restaurants
                where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                orderby r.Name
                select r;
        }

        public Restaurant GetById(int id) => _restaurants.FirstOrDefault(o => o.Id == id);
        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(o => o.Id) + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.FirstOrDefault(o => o.Id == updatedRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public void Delete(int id)
        {
            var restaurant = _restaurants.FirstOrDefault(o => o.Id == id);
            if (restaurant != null)
            {
                _restaurants.Remove(restaurant);
            }
        }

        public int Commit() => 0;
    }
}