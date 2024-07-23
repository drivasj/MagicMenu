namespace DigitalMenu.Models.EntitySystem
{
    public class Application
    {
        public int IdApplication { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public string RegisterUser { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
        public string Display { get; set; }
        public string Icon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menu> menu { get; set; }
    }
}
