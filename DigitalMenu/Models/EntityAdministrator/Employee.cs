using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MotherLastName { get; set; }

        [StringLength(50)]
        public string Document { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string RegisterUser { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        public bool Active { get; set; }
        public EmployeeDetails Employeedetails { get; set; }
    }
}
