using DigitalMenu.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class Typesystemvariable
    {
        [Key]
        public int IdTypesystemvariable { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<Systemvariable> Systemvariables { get; set; }
    }
}
