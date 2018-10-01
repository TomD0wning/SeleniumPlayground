using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeleniumPlayground.Models;
using SeleniumPlayground.Services;
using SeleniumPlayground.ViewModels;


namespace SeleniumPlayground.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        //used for one http request
        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Index()
        {

            //instantiate a new instance of Restaurant.
            var model = new HomeIndexViewModel
            {
                Restaurants = _restaurantData.GetAll()
            };

            /** For using ObjectResult as the return **/
            //The controller only knows that we want a Restaurant result so will place it into an ObjectResult. 
            //Then somthing later in the pipeline will figure out what to do
            //ObjectResult as does object negotiation - think REST
            //return new ObjectResult(model);

            return View(model);

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            //Checks the model state
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();

                newRestaurant.Name = model.Name;
                newRestaurant.Address = model.Address;
                newRestaurant.Owner = model.Owner;
                newRestaurant.Rating = model.Rating;
                newRestaurant.Cuisine = model.Cuisine;

                newRestaurant = _restaurantData.Add(newRestaurant);

                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });

            }
            else
            {
                return View();
            }
        }


        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Details");
            }

            _restaurantData.Edit(_restaurantData.Get(id));
            return View(model);
        }

        [HttpPost]
        public IActionResult Remove(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                _restaurantData.Delete(model);
                return View();
;           }

            return View();
        }
    }
}
