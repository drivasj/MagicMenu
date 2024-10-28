using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class Company
    {
        [Key]
        public int IdCompany { get; set; }

        [StringLength(150)]
        public string NameCompany { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
        [StringLength(150)]
        public string TaxId { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public bool CenterDistribution { get; set; }
        public bool CompanyFather { get; set; }
        public int RoleCompanyId { get; set; }
        public RoleCompany roleCompany { get; set; }
        public int CountryId { get; set; }
        public Country country { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [StringLength(100)]
        public string RegisterUser { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(100)]
        public string LastUpdateUser { get; set; }

        public bool Active { get; set; }
    }
}
