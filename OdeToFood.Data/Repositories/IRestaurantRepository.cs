using System.Collections.Generic;
using OdeToFood.Core.Entities;

namespace OdeToFood.Data.Repositories
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetRestaurants();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurant(int id);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(Restaurant restaurant);
        int GetCount();
        bool Commit();
    }
}
