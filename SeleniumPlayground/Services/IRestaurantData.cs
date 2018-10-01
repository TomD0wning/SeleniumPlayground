using System;
using System.Collections.Generic;
using SeleniumPlayground.Models;


namespace SeleniumPlayground.Services
{

    /*
     * Interface to define interactions with the restaurant model
     */

    public interface IRestaurantData
    {
        //Using IEnumerable to return a read-only sequence of elements - this stop methods from ICollections being used when implementing IResturantData
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int Id);
        Restaurant Add(Restaurant restaurant);
        bool Delete(Restaurant restaurant);
        Restaurant Edit(Restaurant restaurant);
    }
}
