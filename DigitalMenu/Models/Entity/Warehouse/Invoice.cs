using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class Invoice
    {
        public int IdInvoice { get; set; }
        public int NumberInvoice { get; set; }
        public int EmployeeId { get; set; }
        public int NameClient { get; set; }
        public int TaxId { get; set; }

        public int ClientPhone { get; set; }
        public int ClientEmail { get; set; }
        public int SubTotal { get; set; }
        public int Taxotal { get; set; }
        public int Total { get; set; }
        public int Tax { get; set; }

        public DateTime RegisterDate { get; set; }

        [StringLength(100)]
        public string RegisterUser { get; set; }
        public bool Active { get; set; }
    }
}
