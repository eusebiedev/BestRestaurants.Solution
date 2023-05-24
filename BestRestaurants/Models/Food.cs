using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestRestaurants.Models
{
  public class Food
  {
    public int FoodId { get; set; }

    [Required(ErrorMessage = "The food can't be empty!")]
    public string FoodType { get; set; }
    public string FoodPrice { get; set; }

    public List<RestaurantFood> JoinEntities { get;}
  }
}

