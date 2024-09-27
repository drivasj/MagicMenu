using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Services.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<List<ApplicationViewModel>> ListApplications();
        Task<List<MenuViewModel>> ListMenu();
        Task<List<MenuSelect>> ListMenuSingAsignar(int idRol);
        Task<List<EmployeeDTO>> ListUser();
        Task<List<RoleViewModel>> Roles();
        Task<bool> SaveApplication(ApplicationViewModel model);
        Task<bool> SaveMenu(MenuViewModel model);
        Task<bool> Rolemenu(RoleMenuViewModel model);
        Task<bool> SaveRole(RoleViewModel model);
        Task<UserDTO> _getDetailUser(int idUser);
        Task<ApplicationViewModel> _getDetailApp(int idApp);
        Task<bool> EditApp(ApplicationViewModel model);
        Task<bool> UpdateStateApp(int idApplication);
        Task<CreateMenuViewModel> _getDetailMenu(int idMenu);
        Task<bool> Editmenu(CreateMenuViewModel model);
        Task<RoleViewModel> _getDetailRole(int idRole);
        Task<bool> EditRole(RoleViewModel model);
        Task<bool> UpdateStateRole(int idRole);
        Task<bool> UpdateStateMenu(int idMenu);
    }
}
