using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdeToFood.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly OdeToFoodDbContext _context;

        public IndexModel(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
