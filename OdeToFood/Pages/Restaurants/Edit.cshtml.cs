using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Data;
using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();

            Restaurant = restaurantId.HasValue ? _restaurantData.GetById(restaurantId.Value) : new Restaurant();

            if (Restaurant == null)
            {
                RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (!ModelState.IsValid) return Page();

            if (Restaurant.Id > 0)
            {
                _restaurantData.Update(Restaurant);
            }
            else
            {
                _restaurantData.Add(Restaurant);
            }

            TempData["Message"] = "Restaurant Saved!";
            _restaurantData.Commit();

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}
