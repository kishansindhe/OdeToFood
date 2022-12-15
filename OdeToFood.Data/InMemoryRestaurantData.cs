using OdeToFood.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> Restaurants { get; set; }

        public InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>
            {
                new Restaurant { Cuisine = CuisineType.Chinese, Id = 1, Location = "Gandhi Road", Name = "ShinGin" },
                new Restaurant { Cuisine = CuisineType.Indian, Id = 2, Location = "West In", Name = "Eat Street" },
                new Restaurant { Cuisine = CuisineType.Italian, Id = 3, Location = "Down Hill", Name = "La Foodie" }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from restaurant in Restaurants
                   where string.IsNullOrEmpty(name) || restaurant.Name.Contains(name)
                   orderby restaurant.Name
                   select restaurant;
        }

        public Restaurant GetById(int restaurantId)
        {
            return Restaurants.SingleOrDefault(restaurant => restaurant.Id == restaurantId);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = Restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant == null) return null;

            restaurant.Cuisine = updatedRestaurant.Cuisine;
            restaurant.Location = updatedRestaurant.Location;
            restaurant.Name = updatedRestaurant.Name;

            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            Restaurants.Add(newRestaurant);
            newRestaurant.Id = Restaurants.Max(r => r.Id) + 1;

            return newRestaurant;
        }

        public Restaurant Delete(int restaurantId)
        {
            var restaurant = Restaurants.FirstOrDefault(r => r.Id == restaurantId);
            if (restaurant == null) return null;

            Restaurants.Remove(restaurant);

            return restaurant;
        }

        public int GetRestaurantsCount()
        {
            return Restaurants.Count;
        }

        public int Commit()
        {
            return 0;
        }
    }
}