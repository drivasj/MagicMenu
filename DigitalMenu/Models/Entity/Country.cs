using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class Country
    {
        [Key]
        public int IdCountry { get; set; }

        [StringLength(100)]
        public string NameCountry { get; set; }

        [StringLength(50)]
        public string CodeCountry { get; set; }
        public bool Active { get; set; }
    }
}
