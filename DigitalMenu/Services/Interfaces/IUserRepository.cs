
using DigitalMenu.Models.DTO.UserEmployee;

namespace DigitalMenu.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> EditUserEmployee(UserDTO model);
        Task<int> GetLastUserId();
        int GetUserId();
        Task<bool> SaveUserEmployee(UserDTO model);
    }
}
