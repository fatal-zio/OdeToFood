using System.Collections.Generic;
using System.Threading.Tasks;
using OdeToFood.Core.Entities;

namespace OdeToFood.Data.Repositories
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetRestaurants();
        Task<IEnumerable<Restaurant>> GetRestaurantsAsync();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurant(int id);
        Task<Restaurant> GetRestaurantAsync(int id);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(Restaurant restaurant);
        int GetCount();
        Task<bool> RestaurantExistsAsync(int id);
        bool Commit();
        Task<bool> CommitAsync();
    }
}
