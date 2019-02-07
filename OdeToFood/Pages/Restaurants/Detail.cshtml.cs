using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Core.Entities;
using OdeToFood.Data;
using OdeToFood.Data.Repositories;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantData;
        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantRepository restaurantData) => _restaurantData = restaurantData;

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurant(restaurantId);

            return Restaurant == null ? 
                (IActionResult) RedirectToPage("./NotFound") : 
                Page();
        }
    }
}