using SeleniumPlayground.Models;
using System.ComponentModel.DataAnnotations;

namespace SeleniumPlayground.Controllers
{
    public class RestaurantEditModel
    {

        public int Id { get; set; }
        [Required, MaxLength(80)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        [Required, MaxLength(80)]
        [Display(Name = "Resturant Address")]
        public string Address { get; set; }
        [Required, MaxLength(30)]
        [Display(Name = "Proprieter")]
        public string Owner { get; set; }
        [Display(Name = "Restaurant Rating")]
        public double Rating { get; set; }
        [Display(Name = "Cuisine")]
        public FoodType Cuisine { get; set; }
    }
}