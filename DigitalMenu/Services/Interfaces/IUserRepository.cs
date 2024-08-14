
using DigitalMenu.Models.DTO.UserEmployee;

namespace DigitalMenu.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<int> GetLastUserId();
        int GetUserId();
        Task<bool> SaveUserEmployee(UserDTO model);
    }
}
