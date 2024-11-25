﻿using DigitalMenu.Models.Entity.Client;
using DigitalMenu.Models.EntityAdministrator;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class Invoice
    {
        [Key]
        public int IdInvoice { get; set; }
        public int NumberInvoice { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ClientId { get; set; }
        public Client.Client client { get; set; }

        [StringLength(200)]
        public string NameClient { get; set; }

        public int TypedocumentId { get; set; }
        public Typedocument typedocument { get;set; }

        [StringLength(100)]
        public string NumberDocument { get; set; }

        [StringLength(50)]
        public string ClientPhone { get; set; }

        [StringLength(200)]
        public string ClientEmail { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [StringLength(100)]
        public string RegisterUser { get; set; }
        public bool Active { get; set; }

        public List<InvoiceSales> invoiceSales { get; set; }
        public List<InvoiceAddress> invoiceAddress { get; set; }
        public List<SalesMethodPayment> SalesMethodPayment { get; set; }



    }
}
