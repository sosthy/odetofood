using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using OdeToFood.Core;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel: PageModel 
    {
        private readonly ILogger<ListModel> logger;
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantService;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public ListModel(
            ILogger<ListModel> logger, 
            IConfiguration config,
            IRestaurantData restaurantService) 
        {
            this.logger = logger;
            this.config = config;
            this.restaurantService = restaurantService;
        }

        public void OnGet() 
        {
            // Message = "Hello, World !!!";
            Message = config["Message"];
            Restaurants = restaurantService.GetRestaurantsByName(Search);
            this.logger.LogInformation("Dans le constructeur de la page");
        }
    }
}