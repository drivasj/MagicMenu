using DigitalMenu.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.CategoryDishe
{
    public class CategoryDashDTO
    {
        public int IdDishesCategory { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RegisterUser { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Active { get; set; }
    }
}
