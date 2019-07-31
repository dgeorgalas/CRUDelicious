using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;


namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {

        private MyContext dbContext;
        //here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(x => x.CreatedAt).ToList();
            return View(AllDishes);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Dish newDish)
        {
            Console.WriteLine(newDish);
            Console.WriteLine(newDish.ChefName);
            Console.WriteLine(newDish.DishName);
            Console.WriteLine(newDish.Calories);
            Console.WriteLine(newDish.Tastiness);
            Console.WriteLine(newDish.Description);

            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet("{tempId}")]
        public IActionResult Dish(int tempId)
        {
            Dish singleDish = dbContext.Dishes.SingleOrDefault(x => x.DishId == tempId);
            return View(singleDish);
        }


        [HttpGet("edit/{tempId}")]
        public IActionResult EditDish(int tempId)
        {
            Dish singleDish = dbContext.Dishes.SingleOrDefault(x => x.DishId == tempId);
            return View(singleDish);

        }

        [HttpPost("edit/{tempId}")]
        public IActionResult Edit(int tempId, Dish editDish)
        {
            if(ModelState.IsValid)
            {
                Dish singleDish = dbContext.Dishes.SingleOrDefault(x => x.DishId == tempId);

                singleDish.ChefName = editDish.ChefName;
                singleDish.DishName = editDish.DishName;
                singleDish.Calories = editDish.Calories;
                singleDish.Tastiness = editDish.Tastiness;
                singleDish.Description = editDish.Description;
                singleDish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("Dish");
            }
            else
            {
                return View("EditDish");
            }
        }

        [HttpGet("delete/{tempId}")]
        public IActionResult Delete(int tempId)
        {
            Dish deleteDish = dbContext.Dishes.SingleOrDefault(x => x.DishId == tempId);
            dbContext.Dishes.Remove(deleteDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
