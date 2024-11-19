using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class NoteNaturalProduct
    {
        [Key]
        public int IdNaturalProduct { get; set; }
        public int NaturalId { get; set; }
        public NoteNatural natural { get; set; }
        public int ProductId { get; set; }
        public Product.Product product { get; set; }

        [StringLength(100)]
        public string CodeProduct { get; set; }

        [StringLength(100)]
        public string NameProduct { get; set; }
        public decimal PriceSale { get; set; }
        public decimal PriceTax { get; set; }
        public decimal ProductCost { get; set; }
        public int Quantity { get; set; }
        public bool Ckeck { get; set; }
    }
}
