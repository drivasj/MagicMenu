using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Administrator
{
    public class RoleViewModel
    {
        public int IdRole { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Privilege { get; set; }
        public bool Active { get; set; }

    }
}
