using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
        public int EmployeeId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [StringLength(50)]
        public string RegisterUser { get; set; }
        public int IdCompany { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(50)]
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? PasswordUpdate { get; set; }
        public Roleuser roleuser { get; set; }
    }
}
