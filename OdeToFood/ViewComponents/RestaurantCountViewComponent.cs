using System;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantService;

        public RestaurantCountViewComponent(IRestaurantData restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        public IViewComponentResult Invoke()
        {
            int count = restaurantService.GetCountOfRestaurants();
            return View(count);
        }
    }
}