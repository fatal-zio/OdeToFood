using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core.Entities;
using OdeToFood.Core.Enums;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public void EnsureSeedDataExists()
        {
            if (Restaurants.Any())
            {
                return;
            }

            var sampleRestaurants = new List<Restaurant>
            {
                new Restaurant { Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant { Name = "Joe's Mexican Restaurant", Location = "Texas", Cuisine = CuisineType.Mexican },
                new Restaurant { Name = "Jeffrey's Lounge", Location = "Manitoba", Cuisine = CuisineType.Comfort },
                new Restaurant { Name = "Clay Oven", Location = "Manitoba", Cuisine = CuisineType.Indian }
            };

            Restaurants.AddRange(sampleRestaurants);
            SaveChanges();
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
