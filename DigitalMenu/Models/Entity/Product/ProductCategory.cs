using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.Entity.Product
{
    public class ProductCategory
    {
        [Key]
        public int IdProductCategory { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
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
    }
}
