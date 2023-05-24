using System.Collections.Generic;

namespace BestRestaurants.Models
{
  public class Food
  {
    public int FoodId { get; set; }
    public string FoodType { get; set; }
    public string FoodPrice { get; set; }

    public List<RestaurantFood> JoinEntities { get;}
  }
}

