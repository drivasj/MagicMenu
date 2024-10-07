using DigitalMenu.Services.Interfaces;
using TestWeb;

namespace DigitalMenu.Services
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IUserRepository userRepository;

        public ProductRepository(ApplicationDbContext context, IUserRepository userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
        }
    }
}
