using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Services.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<List<ApplicationViewModel>> ListApplications();
        Task<List<MenuViewModel>> ListMenu();
        Task<ActionResult<List<EmployeeDTO>>> ListUser();
        Task<bool> SaveApplication(ApplicationViewModel model);
        Task<bool> SaveMenu(MenuViewModel model);
    }
}
