using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class RestaurantDetails
    {
        public int IdRestaurantDetails { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public string TaxId { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
