using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants {
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        public readonly IRestaurantData restaurantService;

        public DetailModel(IRestaurantData restaurantService)
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
    }
}