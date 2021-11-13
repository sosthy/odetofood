using System.Linq;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData 
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData() 
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Manège RP 4ieme", Location = "Douala", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Pizzaria Priso", Location = "Yaoundé", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Diapazon Coridor", Location = "Dschang", Cuisine = CuisineType.Mexican }
            };
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            Restaurant restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
                restaurants.Remove(restaurant);
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            var orderedRestaurants = restaurants.OrderBy(r => r.Name);
            return orderedRestaurants;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return restaurants
                    .Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name))
                    .OrderBy(r => r.Name);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            Restaurant restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null) 
            {
                restaurant.Id = updatedRestaurant.Id;
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
