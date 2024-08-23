using DigitalMenu.Models.Entity;
using DigitalMenu.Models.EntityAdministrator;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.DTO.UserEmployee
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        public int IdEmployee { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string MotherName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string DocumentNR { get; set; }

        //--- employeeDetails
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        //-- roleUser
        [Required]
        public int IdRole { get; set; }       
    }
}
