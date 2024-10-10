using DigitalMenu.Models.Entity.Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Product
{
    public class ProductViewModel
    {
        public int IdProduct { get; set; }
        public string Code { get; set; }
        public int ProductCategoryId { get; set; }
        public bool StatusPromotion { get; set; }
        public int IdCompany { get; set; }
        public bool Active { get; set; }
        public string NameCategory { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ProductTaxId { get; set; }
        public string UrlImage { get; set; }
        public List<ProductCategoryViewModel> ProductsCategory { get; set; }
        public List<TwoElement> ProductTax { get; set; }

    }
}
