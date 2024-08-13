using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class Menu
    {
        [Key]
        public int IdMenu { get; set; }
        public int ApplicationId { get; set; }
        public Application application { get; set; }

        [StringLength(100)]
        public string Area { get; set; }

        [StringLength(100)]
        public string Controller { get; set; }

        [StringLength(100)]
        public string Action { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public bool Movil { get; set; }

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
        public List<Rolemenu> rolemenu { get; set; }
    }
}
