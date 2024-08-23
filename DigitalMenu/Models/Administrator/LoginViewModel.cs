using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Administrator
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Error.Requerido")]
        public string User { get; set; }

        [Required(ErrorMessage = "Error.Requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Recuerdame")]
        public bool Recuerdame { get; set; }
    }
}
