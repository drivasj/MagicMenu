using Microsoft.AspNetCore.Mvc;
using DigitalMenu.Models.EntityAdministrator;
using TestWeb;


namespace DigitalMenu.Controllers
{
    public class UserAdminController : Controller
    {
        public ApplicationDbContext Context { get; }

        public UserAdminController(ApplicationDbContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(string userName, string password)
        {
            var registerUser = "Admin";

            var user = new User
            {
                UserName = userName,
                Password = password,
                IdEmployee = 1,
                RegisterDate = DateTime.Now,
                RegisterUser = registerUser,
                IdCompany = 1,
                Active = true
            };

            Context.Add(user);
            await Context.SaveChangesAsync();
            return View();
        }
    }
}
