using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class Rolemenu
    {
        [Key]
        public int IdRoleMenu { get; set; }
        public int RoleId { get; set; }
        public Role role { get; set; }
        public int MenuId { get; set; }
        public Menu menu { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(100)]
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
    }
}
