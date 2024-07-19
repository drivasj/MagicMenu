using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class Dishe
    {
        [Key]
        public int IdDishes { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public int IdDishesCategory { get; set; }
        public DisheCategory Dishescategory { get; set; }
        public int IdRestaurant { get; set; }
        public Restaurant Restaurant { get; set; }
        public string RegisterUser { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Active { get; set; }
    }
}
