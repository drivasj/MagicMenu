using DigitalMenu.Models.Entity.Client;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class State
    {
        [Key]
        public int IdState { get; set; }

        [StringLength(100)]
        public string NameState { get; set; }

        [StringLength(50)]
        public string CodeState { get; set; }
        public int CountryId { get; set; }
        public Country country { get; set; }
        public bool Active { get; set; }
    }
}
