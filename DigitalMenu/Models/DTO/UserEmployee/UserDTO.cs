using DigitalMenu.Models.Entity;
using DigitalMenu.Models.EntityAdministrator;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.DTO.UserEmployee
{
    public class UserDTO
    {
        public string UserName { get; set; }
        //public string Password { get; set; }
        public int IdEmployee { get; set; }

        ///--------employee
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNR { get; set; }

        //--- employeeDetails
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        //-- roleUser
        public int IdRole { get; set; }       
    }
}
