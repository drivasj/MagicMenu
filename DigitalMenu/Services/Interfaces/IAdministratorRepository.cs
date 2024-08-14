using DigitalMenu.Models.Administrator;

namespace DigitalMenu.Services.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<bool> SaveApplication(ApplicationViewModel model);
        Task<bool> SaveMenu(MenuViewModel model);
    }
}
