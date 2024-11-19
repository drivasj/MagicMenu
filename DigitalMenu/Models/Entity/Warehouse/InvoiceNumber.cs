using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class InvoiceNumber
    {
        public int IdInvoiceNumber { get; set; }
        public int NumberInvoice { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }
        public string RegisterUser { get; set; }
    }
}
