using System.ComponentModel.DataAnnotations;

namespace SeleniumPlayground.Models
{
    public class Restaurant
    {

        /*
         * Model for a restaurant
         */

        public int Id { get; set; }
        [Display(Name ="Restaurant Name")]    
        public string Name { get; set; }
        [Display(Name ="Resturant Address")]
        public string Address { get; set; }
        [Display(Name ="Proprieter")]
        public string Owner { get; set; }
        [Display(Name ="Restaurant Rating")]
        public double Rating { get; set; }
        [Display(Name ="Cuisine")]
        public FoodType Cuisine { get; set; }

    }
}
