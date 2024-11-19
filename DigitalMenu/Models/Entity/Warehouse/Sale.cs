using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class Sale
    {
        //todas las ventas natural y juridica
        [Key]
        public int IdSale { get; set; }
        public int IdSaleType { get; set; }
        public SaleType saletype { get; set; }
        public int NumberSale { get; set; }
        public bool StatusReturn { get; set; }
        public bool StatusInvoice { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ExpirationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [StringLength(100)]
        public string RegisterUser { get; set; }
        public bool Active { get; set; }

        public List<SalesMethodPayment> salesMethodPayment { get; set; }

        public List<InvoiceSales> invoiceSales { get; set; }

    }
}
