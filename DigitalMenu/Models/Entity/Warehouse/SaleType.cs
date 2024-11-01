using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class SaleType
    {
        [Key]
        public int IdSaleType { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
