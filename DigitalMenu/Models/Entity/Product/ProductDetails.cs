using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.Entity.Product
{
    public class ProductDetails
    {
        [Key]
        public int IdProductDetails { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ProductTaxId { get; set; }
        public ProductTax productTax { get; set; }
      
        [StringLength(400)]
        public string UrlImage { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime LastUpdate { get; set; }

        [StringLength(100)]
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
    }
}
