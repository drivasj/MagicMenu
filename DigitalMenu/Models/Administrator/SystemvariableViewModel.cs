using System.ComponentModel.DataAnnotations;

namespace DigitalMenu.Models.Administrator
{
    public class SystemvariableViewModel
    {
        public int IdSystemVariable { get; set; }
        public int TypesystemvariableId { get; set; }
        public int IdCompany { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(100)]
        public string ValueString { get; set; }
        public decimal ValueNumeric { get; set; }
        public bool Active { get; set; }

        public IEnumerable<ApplicationViewModel> Application { get; set; }


    }
}
