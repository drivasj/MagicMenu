namespace DigitalMenu.Models.EntitySystem
{
    public class Role
    {
        public int IdRole { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Privilege { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public string RegisterUser { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
        public string NameRoleNotification { get; set; }
        public System.TimeSpan TimeInitial { get; set; }
        public System.TimeSpan TimeFinal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rolemenu> rolemenu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rolemenu> roleuser { get; set; }
    }
}
