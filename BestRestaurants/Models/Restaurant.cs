using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestRestaurants.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    
    [Required(ErrorMessage = "The restaurant's name can't be empty!")]
    public string Name { get; set; }

    public string Address { get; set; }
    public string Phone { get; set; }
    public string Description { get; set; }
    public int CuisineId { get; set; }
    public Cuisine Cuisine { get; set; }

    public List<RestaurantFood> JoinEntities { get;} 

  }
}