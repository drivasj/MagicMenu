using DigitalMenu.Models.DTO.UserEmployee;
using DigitalMenu.Models.EntityAdministrator;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Administrator
{
    public class CreateUserViewModel
    {
        //Employee
        public int IdEmployee { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Document { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string UserName { get; set; }
        //EmployeeDetails
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Phone { get; set; }
        public string Adress { get; set; }
        public IEnumerable<RoleViewModel> Roles { get; set; }
        public IEnumerable<EmployeeDTO> Employees { get; set; }

        // role
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public int IdRole { get; set; }

    }
}
