using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class Dishes
    {
        [Key]
        public int IdDishes { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdDishesCategory { get; set; }
        public DishesCategory DishesCategory { get; set; }
        public int IdRestaurant { get; set; }
        public string RegisterUser { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Active { get; set; }
    }
}
