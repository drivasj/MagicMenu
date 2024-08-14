using DigitalMenu.Models.Administrator;

namespace DigitalMenu.Services.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<List<ApplicationViewModel>> ListApplications();
        Task<List<MenuViewModel>> ListMenu();
        Task<bool> SaveApplication(ApplicationViewModel model);
        Task<bool> SaveMenu(MenuViewModel model);
    }
}
