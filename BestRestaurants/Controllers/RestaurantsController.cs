using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public RestaurantsController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      if (restaurant.CuisineId == 0)
      {
        return RedirectToAction("Index");
      }
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants
                                      .Include(restaurant => restaurant.Cuisine)
                                      .Include(restaurant => restaurant.JoinEntities)
                                      .ThenInclude(join => join.Food)      
                                      .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Restaurants.Update(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFood(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      ViewBag.FoodId = new SelectList(_db.Foods, "FoodId", "FoodType");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult AddFood(Restaurant restaurant, int FoodId)
    {
      #nullable enable
      RestaurantFood? joinEntity = _db.RestaurantFoods.FirstOrDefault(join => (join.FoodId == FoodId && join.RestaurantId == restaurant.RestaurantId));
      #nullable disable
      
      if (joinEntity == null && FoodId != 0)
      {
        _db.RestaurantFoods.Add(new RestaurantFood() { FoodId = FoodId, RestaurantId = restaurant.RestaurantId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = restaurant.RestaurantId });
    }  

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      RestaurantFood joinEntry = _db.RestaurantFoods.FirstOrDefault(entry => entry.RestaurantFoodId == joinId);
      _db.RestaurantFoods.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


  }
}