using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class RoleCompany
    {
        [Key]
        public int IdRoleCompany { get; set; }

        [StringLength(150)]
        public string NameRoleCompany { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
