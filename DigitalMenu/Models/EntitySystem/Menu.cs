using static System.Net.Mime.MediaTypeNames;

namespace DigitalMenu.Models.EntitySystem
{
    public class Menu
    {
        public int IdMenu { get; set; }
        public int IdApplication { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public string RegisterUser { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
        public virtual Application application { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rolemenu> rolemenu { get; set; }
    }
}
