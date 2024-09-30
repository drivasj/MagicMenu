
using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;

namespace DigitalMenu.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> EditUserEmployee(CreateUserViewModel model);
        string GetUserName();
        Task<bool> SaveUserEmployee(CreateUserViewModel model);
        Task<bool> UpdateStateUser(int idUser);
        Task<bool> UserExist(string userName);
    }
}
