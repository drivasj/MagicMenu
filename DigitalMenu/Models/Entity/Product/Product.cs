using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.Entity.Product
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory productCategory { get; set; }
        public bool StatusPromotion { get; set; }
        public int IdCompany { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }
        [StringLength(100)]
        public string RegisterUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdate { get; set; }
        [StringLength(100)]
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
        public ProductDetails productDetails { get; set; }
    }
}
