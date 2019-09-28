using System.Collections;
using System.Collections.Generic;
using OdeToFoodCore.Core;

namespace OdeToFoodCore.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}
