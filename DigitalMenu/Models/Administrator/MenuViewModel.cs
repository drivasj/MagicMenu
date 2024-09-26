using DigitalMenu.Models.EntityAdministrator;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Administrator
{
    public class MenuViewModel
    {

        public int IdMenu { get; set; }
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string Area { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Controller { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Action { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

    }
}
