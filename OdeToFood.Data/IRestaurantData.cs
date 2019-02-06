using OdeToFood.Core;
using System.Collections.Generic;
using OdeToFood.Core.Entities;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Update(Restaurant updatedRestaurant);
        void Delete(int id);
        int Commit();
    }
}
