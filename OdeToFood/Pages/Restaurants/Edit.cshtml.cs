using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Core.Entities;
using OdeToFood.Core.Enums;
using OdeToFood.Data;
using OdeToFood.Data.Repositories;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantRepository restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        } 

        public IActionResult OnGet(int? restaurantId)
        {
            GetCuisines();

            Restaurant = restaurantId.HasValue ? _restaurantData.GetRestaurant((int)restaurantId) : new Restaurant();

            return Restaurant == null ? 
                (IActionResult) RedirectToPage("./NotFound") : 
                Page();
        }

        public IActionResult OnPost()
        {
            GetCuisines();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                _restaurantData.Update(Restaurant);
            }
            else
            {
                _restaurantData.Add(Restaurant);
            }
            
            _restaurantData.Commit();
            TempData["Message"] = $"{Restaurant.Name} saved!";
            return RedirectToPage("./List");
        }

        private void GetCuisines()
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
        }
    }
}