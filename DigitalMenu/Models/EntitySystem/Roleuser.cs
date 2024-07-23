using System.Data;

namespace DigitalMenu.Models.EntitySystem
{
    public class Roleuser
    {
        public long IdRoleUser { get; set; }
        public int IdRole { get; set; }
        public int IdUser { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
        public virtual Role role { get; set; }
        public virtual User user { get; set; }
    }
}
