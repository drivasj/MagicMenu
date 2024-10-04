using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class TypesystemvariableViewModel
    {
        public int IdTypesystemvariable { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}
