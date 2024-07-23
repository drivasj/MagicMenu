namespace DigitalMenu.Models.EntitySystem
{
    public class User
    {
        public int IdUser { get; set; }
        public string User1 { get; set; }
        public string Password { get; set; }
        public int IdEmployee { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public string RegisterUser { get; set; }
        public int IdCompany { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
        public bool Online { get; set; }
        public string UserTelegram { get; set; }
        public long ChatIdTelegram { get; set; }
        public System.DateTime PasswordUpdate { get; set; }
        public bool NotificationPush { get; set; }
        public virtual ICollection<Roleuser> roleuser { get; set; }

    }
}
