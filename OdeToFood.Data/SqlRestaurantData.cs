using System;
using System.Linq;
using System.Collections.Generic;
using OdeToFood.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext odeToFoodDb;

        public SqlRestaurantData(OdeToFoodDbContext odeToFoodDb)
        {
            this.odeToFoodDb = odeToFoodDb;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            odeToFoodDb.Restaurants.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
            return odeToFoodDb.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            Restaurant restaurant = GetById(id);
            if (restaurant != null)
                odeToFoodDb.Restaurants.Remove(restaurant);
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return odeToFoodDb.Restaurants.ToList();
        }

        public Restaurant GetById(int id)
        {
            Restaurant restaurant = odeToFoodDb.Restaurants.FirstOrDefault(r => r.Id == id);
            return restaurant; 
        }

        public int GetCountOfRestaurants()
        {
            return odeToFoodDb.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return odeToFoodDb.Restaurants
                    .Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                    .OrderBy(r => r.Name)
                    .ToList();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            EntityEntry<Restaurant> entityEntry = odeToFoodDb.Restaurants.Attach(updatedRestaurant);
            entityEntry.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
