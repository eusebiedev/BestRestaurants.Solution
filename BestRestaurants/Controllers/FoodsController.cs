using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
  public class FoodsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public FoodsController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Foods.ToList());
    }

    public ActionResult Details(int id)
    {
      Food thisFood = _db.Foods
                          .Include(food => food.JoinEntities)
                          .ThenInclude(join => join.Restaurant)
                          .FirstOrDefault(food => food.FoodId == id);
      return View(thisFood);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Food food)
    {
      _db.Foods.Add(food);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddRestaurant(int id)
    {
      Food thisFood = _db.Foods.FirstOrDefault(foods => foods.FoodId == id);
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View(thisFood);
    }

    [HttpPost]
    public ActionResult AddRestaurant(Food food, int RestaurantId)
    {
      #nullable enable
      RestaurantFood? joinEntity = _db.RestaurantFoods.FirstOrDefault(join => (join.RestaurantId == RestaurantId && join.FoodId == food.FoodId));
      #nullable disable
      if (joinEntity == null && RestaurantId != 0)
      {
        _db.RestaurantFoods.Add(new RestaurantFood() { RestaurantId = RestaurantId, FoodId = food.FoodId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = food.FoodId });
    }

    public ActionResult Edit(int id)
    {
      Food thisFood = _db.Foods.FirstOrDefault(foods => foods.FoodId == id);
      return View(thisFood);
    }

    [HttpPost]
    public ActionResult Edit(Food food)
    {
      _db.Foods.Update(food);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Food thisFood = _db.Foods.FirstOrDefault(foods => foods.FoodId == id);
      return View(thisFood);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Food thisFood = _db.Foods.FirstOrDefault(foods => foods.FoodId == id);
      _db.Foods.Remove(thisFood);
      _db.SaveChanges();
      return RedirectToAction("Index");
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