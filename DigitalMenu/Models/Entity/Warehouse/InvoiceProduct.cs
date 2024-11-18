using DigitalMenu.Migrations;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class InvoiceProduct
    {
        /// <summary>
        /// items detallados de la factura
        /// </summary>
        [Key]
        public int IdSaleProduct { get; set; }
        public int InvoiceId { get; set; }
        public Invoice invoice { get; set; }
        public int ProductId { get; set; }

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
