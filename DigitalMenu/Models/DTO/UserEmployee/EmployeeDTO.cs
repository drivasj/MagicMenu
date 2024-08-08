using DigitalMenu.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.DTO.UserEmployee
{
    public class EmployeeDTO
    {
        public int IdEmployee { get; set; }
        public int Code { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Document { get; set; }
        [StringLength(500)]
        public string UserName { get; set; }
        public string RegisterUser { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Active { get; set; }
        public EmployeeDetails Employeedetails { get; set; }

        [StringLength(250)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(250)]
        public string Adress { get; set; }
    }
}
