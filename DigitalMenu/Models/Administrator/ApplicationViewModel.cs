using DigitalMenu.Models.EntityAdministrator;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Administrator
{
    public class ApplicationViewModel
    {
        public int IdApplication { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Display { get; set; }
        public string Icon { get; set; }
    }
}
