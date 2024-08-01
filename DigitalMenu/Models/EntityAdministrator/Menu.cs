using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class Menu
    {
        [Key]
        public int IdMenu { get; set; }
        public int IdApplication { get; set; }
        public Application application { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterUser { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
        public virtual List<Rolemenu> rolemenu { get; set; }
    }
}
