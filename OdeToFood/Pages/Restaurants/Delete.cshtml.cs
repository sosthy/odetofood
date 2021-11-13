using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        private readonly IRestaurantData restaurantService;

        public DeleteModel(IRestaurantData restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantService.GetById(restaurantId);

            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            Restaurant restaurant = restaurantService.Delete(restaurantId);
            restaurantService.Commit(); 

            if (restaurant == null)
                return RedirectToPage("./NotFound");

            TempData["Message"] = $"{restaurant.Name} deleted !";

            return RedirectToPage("./List");
        }
    }
}