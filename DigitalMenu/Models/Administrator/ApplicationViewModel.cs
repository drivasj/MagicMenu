using DigitalMenu.Models.EntityAdministrator;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Administrator
{
    public class ApplicationViewModel
    {
        public int IdApplication { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string Name { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string Description { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string Display { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string Icon { get; set; }

        public bool Active { get; set; }
    }
}
