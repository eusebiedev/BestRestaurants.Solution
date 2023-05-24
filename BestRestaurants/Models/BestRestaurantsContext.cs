using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Models
{
  public class BestRestaurantsContext : DbContext
  {
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Cuisine> Cuisines { get; set; }

    public DbSet<Food> Foods { get; set; }
    public DbSet<RestaurantFood> RestaurantFoods { get; set; }

    public BestRestaurantsContext(DbContextOptions options) : base(options) { }
  }
}