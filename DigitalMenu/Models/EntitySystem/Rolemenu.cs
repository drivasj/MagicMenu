using System.Data;

namespace DigitalMenu.Models.EntitySystem
{
    public class Rolemenu
    {
        public long IdRoleMenu { get; set; }
        public int IdRole { get; set; }
        public int IdMenu { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }

        public virtual Menu menu { get; set; }
        public virtual Role role { get; set; }
    }
}
