using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class NoteNaturalAddress
    {
        [Key]
        public int IdInvoiceAddress { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [StringLength(300)]
        public string Reference { get; set; }

        public int IdCity { get; set; }
        public City city { get; set; }
        public int IdState { get; set; }
        public State state { get; set; }
        public int IdCountry { get; set; }
        public Country country { get; set; }
    }
}
