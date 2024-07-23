using DigitalMenu.Models.EntitySystem;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class Restaurant
    {
        [Key]
        public int IdRestaurant { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(250)]    
        public string RegisterUser { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Active { get; set; }
        public List<RestaurantEmployee> Restaurantemployee { get; set; }
        public List<Dishe> Dishes { get; set; }
        public RestaurantDetails Restaurantdetails { get; set; }



    }
}
