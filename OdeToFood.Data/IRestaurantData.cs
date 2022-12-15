using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetById(int restaurantId);

        Restaurant Update(Restaurant updatedRestaurant);

        Restaurant Add(Restaurant newRestaurant);

        Restaurant Delete(int restaurantId);

        int GetRestaurantsCount();

        int Commit();
    }
}
