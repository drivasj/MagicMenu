using DigitalMenu.Migrations;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class SaleProduct
    {
        [Key]
        public int IdSaleProduct { get; set; }
        public int SaleId { get; set; }
        public Sale sale { get; set; }
        public int ProductId { get; set; }

        public string CodeProduct { get; set; }
        public string NameProduct { get; set; }
        public decimal PriceSale { get; set; }
        public decimal PriceTax { get; set; }
        public decimal ProductCost { get; set; }
        public int Quantity { get; set; }
        public bool Ckeck { get; set; }
    }
}
