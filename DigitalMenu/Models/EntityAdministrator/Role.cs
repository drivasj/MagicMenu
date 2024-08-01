using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Privilege { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterUser { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
        public string NameRoleNotification { get; set; }
        public TimeSpan TimeInitial { get; set; }
        public TimeSpan TimeFinal { get; set; }

        public virtual List<Rolemenu> rolemenu { get; set; }
        public virtual List<Roleuser> roleuser { get; set; }
    }
}
