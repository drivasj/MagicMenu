
using DigitalMenu.Models.DTO.UserEmployee;

namespace DigitalMenu.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> EditUserEmployee(UserDTO model);
        string GetUserName();
        Task<bool> SaveUserEmployee(UserDTO model);
        Task<bool> UpdateStateUser(int idUser);
    }
}
