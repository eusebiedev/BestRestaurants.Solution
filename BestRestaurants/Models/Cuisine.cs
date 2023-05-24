using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestRestaurants.Models
{
  public class Cuisine
  {
    
    [Range(1, int.MaxValue, ErrorMessage = "You must add your restaurant to a cuisine. Have you created a cuisine yet?")]
    public int CuisineId { get; set; }
    
    [Required(ErrorMessage = "The food can't be empty!")]
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Restaurant> Restaurants { get; set; }
  }
}