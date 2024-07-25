using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DigitalMenu.Models.EntitySystem
{
    public class Roleuser
    {
        [Key]
        public long IdRoleUser { get; set; }
        public int IdRole { get; set; }
        public  Role role { get; set; }
        public int IdUser { get; set; }
        public  User user { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
    }
}
