using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core;
using OdeToFood.Data;
using Microsoft.EntityFrameworkCore;


namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantData restaurantService;

        public RestaurantsController(IRestaurantData restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        // api/restaurants
        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return restaurantService.GetAll();
        }

        // api/restaurants/2
        [HttpGet("{id}")]
        public Restaurant GetRestaurants(int id)
        {
            return restaurantService.GetById(id);
        }

    }
}