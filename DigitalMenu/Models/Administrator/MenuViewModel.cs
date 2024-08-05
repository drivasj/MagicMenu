using DigitalMenu.Models.EntityAdministrator;

namespace DigitalMenu.Models.Administrator
{
    public class MenuViewModel
    {
        public int IdApplication { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
