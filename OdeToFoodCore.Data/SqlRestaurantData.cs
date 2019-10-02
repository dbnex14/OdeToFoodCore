using System.Collections.Generic;
using OdeToFoodCore.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFoodCore.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            // Attach tells EntityFremework that we are giving it an object
            // that is already in DB but we want EF to start tracking changes
            // about this object.
            var entity = db.Restaurants.Attach(updatedRestaurant);
            // Tell EF that this entity is modified so that EF has to assume
            // that everything about this restaurant has changed except the Id.
            // Now, when someone calls SaveChanges, EF will issue an UPDATE
            // statement for this restaurant object.
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
