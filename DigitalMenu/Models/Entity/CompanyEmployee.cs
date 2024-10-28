using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DigitalMenu.Models.EntityAdministrator;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Models.Entity
{
    public class CompanyEmployee
    {
        [Key]
        public int CompanyEmployeeId { get; set; }
        public int CompanyId { get; set; }
        public Company company { get; set; }
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [StringLength(100)]
        public string RegisterUser { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(100)]
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
    }
}
