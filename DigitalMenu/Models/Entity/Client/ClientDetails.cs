using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity.Client
{
    public class ClientDetails
    {
        [Key]
        public int IdClientDetails {  get; set; }
        public int ClientId { get; set; }
        public Client client { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [StringLength(300)]
        public string Street { get; set; }
        public int CityId { get; set; }
        public City city { get; set; }

        [StringLength(100)]
        public string PostalCode { get; set; }

        [StringLength(500)]
        public string Reference { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }
        public int Ext { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

    }
}
