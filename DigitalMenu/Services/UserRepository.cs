using DigitalMenu.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestWeb;

namespace DigitalMenu.Services
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int GetUserId()
        {
            int userId = 1;
            return userId;
        }

        public async Task<int> GetLastUserId()
        {
            int userId = 1;

            //int userId = await context.User.MaxAsync(x => x.IdUser);
            return userId;
        }
    }
}
