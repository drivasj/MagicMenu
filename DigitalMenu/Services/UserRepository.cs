using DigitalMenu.Services.Interfaces;

namespace DigitalMenu.Services
{
    public class UserRepository: IUserRepository
    {
        public int GetUserId()
        {
            int userId = 1;
            return userId;
        }
    }
}
