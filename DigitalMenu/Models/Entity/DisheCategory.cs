using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class DisheCategory
    {
        [Key]
        public int IdDishesCategory { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public string RegisterUser { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Active { get; set; }
        public List<Dishe> Dishes { get; set; }
    }
}
