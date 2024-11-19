using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DigitalMenu.Models.Entity.Warehouse
{
    public class SalesMethodPayment
    {
        [Key]
        public int IdSalesMethodPayment { get; set; }
        public int SaleId { get; set; }
        public Sale sale { get; set; }
        public int CompanyId { get; set; }
        public Company company { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public int TipoTransc { get; set; }
        public TypeTransaction typeTransaction { get; set; }
        public int IdSaleNumber { get; set; }
        public int IdReturnNumber { get; set; }
        public int ClientId { get; set; }
        public Client.Client client { get; set; }
        public decimal Amount { get; set; }

        [StringLength(100)]
        public string Reference { get; set; }
        public int SaleTypeId { get; set; }
        public SaleType saleType { get; set; }

        [StringLength(100)]
        public int TypeCurrenty { get; set; }
        public TypeCurrenty typeCurrenty { get; set; }
        public decimal ExchangeRate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [StringLength(100)]
        public string RegisterUser { get; set; }
        public bool Active { get; set; }
    }
}
