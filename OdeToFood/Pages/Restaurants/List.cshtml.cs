using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core.Entities;
using OdeToFood.Data.Repositories;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantRepository _restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantRepository restaurantData)
        {
            _config = config;
            _restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = TempData["Message"] != null ? 
                TempData["Message"].ToString() : 
                _config["Message"];

            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}