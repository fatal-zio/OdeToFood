using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data.Repositories;

namespace OdeToFood.Pages.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantCountViewComponent(IRestaurantRepository restaurantRepository) => _restaurantRepository = restaurantRepository;

        public IViewComponentResult Invoke()
        {
            var count = _restaurantRepository.GetCount();
            return View(count);
        }
    }
}
