using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdEmployee { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterUser { get; set; }
        public int IdCompany { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
        public bool Online { get; set; }
        public string UserTelegram { get; set; }
        public long ChatIdTelegram { get; set; }
        public DateTime PasswordUpdate { get; set; }
        public bool NotificationPush { get; set; }
        public List<Roleuser> roleuser { get; set; }

    }
}
