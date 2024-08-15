using DigitalMenu.Models.DTO.UserEmployee;

namespace DigitalMenu.Models.Administrator
{
    public class TwoListMenuApp
    {
        public IEnumerable<MenuViewModel> Menu { get; set; }
        public IEnumerable<MenuViewModel> MenuSA { get; set; }
        public IEnumerable<ApplicationViewModel> Application { get; set; }
        public IEnumerable<RoleViewModel> Role { get; set; }

    }
}
