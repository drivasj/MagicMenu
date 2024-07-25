using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DigitalMenu.Models.EntitySystem
{
    public class Rolemenu
    {
        [Key]
        public long IdRoleMenu { get; set; }
        public int IdRole { get; set; }
        public Role role { get; set; }
        public int IdMenu { get; set; }
        public Menu menu { get; set; }
        public Nullable<DateTime> LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
    }
}
