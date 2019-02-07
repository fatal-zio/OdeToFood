using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core.Entities;
using OdeToFood.Data.Repositories;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantRepository restaurantRepository) => _restaurantRepository = restaurantRepository;

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantRepository.GetRestaurant(restaurantId);

            return Restaurant == null ? (IActionResult) RedirectToPage("./NotFound") : Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            Restaurant = _restaurantRepository.GetRestaurant(restaurantId);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            _restaurantRepository.Delete(Restaurant);

            _restaurantRepository.Commit();

            TempData["Message"] = $"{Restaurant.Name} was deleted.";
            return RedirectToPage("./List");
        }
    }
}