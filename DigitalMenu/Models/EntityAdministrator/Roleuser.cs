using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class Roleuser
    {
        [Key]
        public int IdRoleUser { get; set; }
        public int RoleId { get; set; }
        public Role role { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(50)]
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
    }
}
