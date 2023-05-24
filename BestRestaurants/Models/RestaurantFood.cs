namespace BestRestaurants.Models
{
  public class RestaurantFood
  {
    public int RestaurantFoodId { get; set; }
    public int FoodId { get; set; }
    public Food Food { get; set; }

    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
  }
}