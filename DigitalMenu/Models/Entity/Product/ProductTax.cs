using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity.Product
{
    public class ProductTax
    {
        [Key]
        public int IdProductTax { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description  { get; set; }
        public decimal Value { get; set; }
    }
}
