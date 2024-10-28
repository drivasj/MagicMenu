using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class City
    {
        [Key]
        public int IdCity { get; set; }

        [StringLength(100)]
        public string NameCity { get; set; }
        public int StateId { get; set; }
        public State country { get; set; }
        public bool Active { get; set; }
    }
}
