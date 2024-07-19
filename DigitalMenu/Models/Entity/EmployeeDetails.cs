using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class EmployeeDetails
    {
        [Key]
        public int IdEmployeeDetails { get; set; }
        [StringLength(250)]
        public string Email {  get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(250)]
        public string Adress { get; set; }
        public int IdEmployee { get; set; }
        public Employee Employee { get; set; }
    }
}
