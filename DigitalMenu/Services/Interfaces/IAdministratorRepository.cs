using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Services.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<List<ApplicationViewModel>> ListApplications();
        Task<List<MenuViewModel>> ListMenu();
        Task<List<MenuViewModel>> ListMenuSingAsignar();
        Task<List<EmployeeDTO>> ListUser();
        Task<List<RoleViewModel>> Roles();
        Task<bool> SaveApplication(ApplicationViewModel model);
        Task<bool> SaveMenu(MenuViewModel model);
        Task<bool> SaveRole(RoleViewModel model);
    }
}
