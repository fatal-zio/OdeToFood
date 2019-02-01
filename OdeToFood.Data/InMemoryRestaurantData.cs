using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 1, Name = "Joe's Mexican Restaurant", Location = "Texas", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 1, Name = "Jeffrey's Lounge", Location = "Manitoba", Cuisine = CuisineType.Comfort },
                new Restaurant { Id = 1, Name = "Clay Oven", Location = "Manitoba", Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in _restaurants
                orderby r.Name
                select r;
        }
    }
}