using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity.Client
{
    public class Typedocument
    {
        [Key]
        public int IdTypeDocument { get; set; }

        [StringLength(100)]
        public string NameDocument { get; set; }
    }
}
