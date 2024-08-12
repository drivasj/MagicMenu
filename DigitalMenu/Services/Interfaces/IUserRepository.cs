
namespace DigitalMenu.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<int> GetLastUserId();
        int GetUserId();
    }
}
