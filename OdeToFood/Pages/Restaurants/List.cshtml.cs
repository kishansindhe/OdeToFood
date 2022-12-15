using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;
using OdeToFood.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;

        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            _configuration = configuration;
            _restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = _configuration["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
