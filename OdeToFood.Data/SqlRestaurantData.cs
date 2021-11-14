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
        private readonly DataContext database;

        public SqlRestaurantData(DataContext database)
        {
            this.database = database;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            database.Restaurants.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
            return database.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            Restaurant restaurant = GetById(id);
            if (restaurant != null)
                database.Restaurants.Remove(restaurant);
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return database.Restaurants.ToList();
        }

        public Restaurant GetById(int id)
        {
            Restaurant restaurant = database.Restaurants.FirstOrDefault(r => r.Id == id);
            return restaurant; 
        }

        public int GetCountOfRestaurants()
        {
            return database.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return database.Restaurants
                    .Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                    .OrderBy(r => r.Name)
                    .ToList();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            EntityEntry<Restaurant> entityEntry = database.Restaurants.Attach(updatedRestaurant);
            entityEntry.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
