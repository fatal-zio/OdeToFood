using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; set; }

        public EditModel(IRestaurantData restaurantData) => _restaurantData = restaurantData;

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);

            return Restaurant == null ? 
                (IActionResult) RedirectToPage("./NotFound") : 
                Page();
        }
    }
}