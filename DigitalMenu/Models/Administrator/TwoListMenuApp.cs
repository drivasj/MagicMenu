using DigitalMenu.Models.DTO.UserEmployee;

namespace DigitalMenu.Models.Administrator
{
    public class TwoListMenuApp
    {
        public IEnumerable<ApplicationViewModel> Application { get; set; }

        public IEnumerable<RoleViewModel> Role { get; set; }
        public IEnumerable<MenuViewModel> Menu { get; set; }

        //public IEnumerable<MenuSelect> MenuSelect { get; set; }
        //public int RolId { get; set; }
    }
}
