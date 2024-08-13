using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class Application
    {
        [Key]
        public int IdApplication { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [StringLength(50)]
        public string RegisterUser { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(50)]
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }

        [StringLength(100)]
        public string Display { get; set; }

        [StringLength(100)]
        public string Icon { get; set; }
        public List<Menu> menu { get; set; }
    }
}
