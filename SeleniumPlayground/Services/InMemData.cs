using System;
using System.Collections.Generic;
using SeleniumPlayground.Models;
using GenFu;
using System.Linq;



namespace SeleniumPlayground.Services
{
    public class InMemData : IRestaurantData
    {
        //Private field declaration...Abstractions of lists are not thread safe.
        List<Restaurant> _restaurants;

        public InMemData()
        {
            GenFu.GenFu.Configure<Restaurant>()
                 .Fill(v => v.Id).WithinRange(1, 100)
                 .Fill(v => v.Address).AsAddress()
                 .Fill(v => v.Name).AsMusicArtistName()
                 .Fill(v => v.Owner).AsFirstName()
                 .Fill(v => v.Rating).WithRandom(GetRatings());
                _restaurants = GenFu.GenFu.ListOf<Restaurant>(10);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int Id)
        {
            return _restaurants.FirstOrDefault(v => v.Id == Id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
                restaurant.Id = _restaurants.Max(r => r.Id) + 1;
                _restaurants.Add(restaurant);
                return restaurant;
        }

        public Restaurant Edit(Restaurant restaurant)
        {
            var temp = _restaurants.FirstOrDefault(v => v.Id == restaurant.Id);

            if (temp != null)
            {
                temp.Name = restaurant.Name;
                temp.Address = restaurant.Address;
                temp.Owner = restaurant.Owner;
                temp.Rating = restaurant.Rating;

                return temp;
            }

            return temp;
        }

        public bool Delete(Restaurant restaurant)
        {
            return _restaurants.Remove(restaurant);
        }


        private IEnumerable<double> GetRatings(){

            List<double> ratings = new List<double>()
            {
                1.0,
                1.5,
                2.0,
                2.5,
                3.0,
                3.5,
                4.0,
                4.5,
                5.0

            };
            return ratings;
        }
       
    }
}
