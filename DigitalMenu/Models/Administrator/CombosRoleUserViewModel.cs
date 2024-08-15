using DigitalMenu.Models.DTO.UserEmployee;

namespace DigitalMenu.Models.Administrator
{
    public class CombosRoleUserViewModel
    {
        public IEnumerable<EmployeeDTO> Employees { get; set; }
        public IEnumerable<RoleViewModel> Roles { get; set; }
    }
}
