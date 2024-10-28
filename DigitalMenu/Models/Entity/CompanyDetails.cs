using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Entity
{
    public class CompanyDetails
    {
        [Key]
        public int IdCompanyDetails { get; set; }
        public int CompanyId { get; set; }
        public Company company { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(350)]
        public string LogoUrl { get; set; }

        [StringLength(350)]
        public string Web { get; set; }

        [StringLength(350)]
        public string Intranet { get; set; }

        [StringLength(350)]
        public string Facebook { get; set; }

        [StringLength(350)]
        public string Twitter { get; set; }

        [StringLength(350)]
        public string Youtube { get; set; }

        [StringLength(350)]
        public string Instagram { get; set; }
    }
}
