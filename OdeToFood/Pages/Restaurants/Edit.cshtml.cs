using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants 
{
    public class EditModel: PageModel 
    {
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        [TempData]
        public string Message { get; set; }
        public IEnumerable<SelectListItem> Cuisines;
        private readonly IRestaurantData restaurantService;
        private readonly IHtmlHelper htmlHelper;

        public EditModel(IRestaurantData restaurantService, IHtmlHelper htmlHelper)
        {
            this.restaurantService = restaurantService;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue) 
            {
                Restaurant = restaurantService.GetById(restaurantId.Value);
                if(Restaurant == null)
                    return RedirectToPage("./NotFound");
            }
            else 
            {
                Restaurant = new Restaurant();
                Restaurant.Location = "Paris";
            }
            return Page(); 
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) 
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if(Restaurant.Id > 0) 
            {
                restaurantService.Update(Restaurant);
            }
            else 
            {
                restaurantService.Add(Restaurant);
            }

            Message = "Restaurant saved !";
            restaurantService.commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}