using DigitalMenu.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.EntityAdministrator
{
    public class Systemvariable
    {
        [Key]
        public int IdSystemVariable { get; set; }
        public int TypesystemvariableId { get; set; }       
        public Typesystemvariable Typesystemvariable { get; set; }
        public int IdCompany { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(100)]
        public string ValueString { get; set; }
        public decimal ValueNumeric { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }
        [StringLength(100)]
        public string RegisterUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdate { get; set; }
        [StringLength(100)]
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }
    }
}
