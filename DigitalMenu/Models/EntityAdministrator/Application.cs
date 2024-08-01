using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class Application
    {
        [Key]
        public int IdApplication { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterUser { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
        public string Display { get; set; }
        public string Icon { get; set; }
        public List<Menu> menu { get; set; }
    }
}
