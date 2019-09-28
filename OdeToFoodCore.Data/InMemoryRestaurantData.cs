using System;
using System.Collections.Generic;
using OdeToFoodCore.Core;
using System.Linq;

namespace OdeToFoodCore.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant{Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Indian },
                new Restaurant{Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Italian }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
