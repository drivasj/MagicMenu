namespace DigitalMenu.Models.Entity.Warehouse
{
    public class InvoiceSales
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public Invoice invoice { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
