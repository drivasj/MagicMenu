using DigitalMenu.Models.EntityAdministrator;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Administrator
{
    public class CreateUserViewModel
    {
        //Employee
        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string Document { get; set; }
        public string UserName { get; set; }

        //EmployeeDetails

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        public IEnumerable<RoleViewModel> Roles { get; set; }


    }
}
