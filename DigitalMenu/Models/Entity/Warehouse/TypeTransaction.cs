using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class TypeTransaction
    {
        [Key]
        public int IdTypeTransaction { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
