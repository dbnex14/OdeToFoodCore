using System;
using Microsoft.EntityFrameworkCore;
using OdeToFoodCore.Core;

namespace OdeToFoodCore.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            : base(options)
        {

        }

        // tell entity framework, our context is Restaurant since we work with restaurants here
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
