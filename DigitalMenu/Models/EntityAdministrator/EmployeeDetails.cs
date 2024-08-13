using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class EmployeeDetails
    {
        [Key]
        public int IdEmployeeDetails { get; set; }
        public int EmployeeId { get; set; }

        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(250)]
        public string Adress { get; set; }
        public Employee Employee { get; set; }
    }
}
