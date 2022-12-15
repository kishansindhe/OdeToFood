using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in _db.Restaurants
                where r.Name.Contains(name) || string.IsNullOrEmpty(name)
                orderby r.Name
                select r;
        }

        public Restaurant GetById(int restaurantId)
        {
            return _db.Restaurants.Find(restaurantId);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;

            return updatedRestaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _db.Add(newRestaurant);

            return newRestaurant;
        }

        public Restaurant Delete(int restaurantId)
        {
            var entityToDelete = GetById(restaurantId);
            if (entityToDelete != null)
            {
                _db.Restaurants.Remove(entityToDelete);
            }

            return entityToDelete;
        }

        public int GetRestaurantsCount()
        {
            return _db.Restaurants.Count();
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}