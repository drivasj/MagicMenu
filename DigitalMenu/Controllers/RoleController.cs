using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.EntityAdministrator;
using Microsoft.AspNetCore.Mvc;
using TestWeb;

namespace DigitalMenu.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext context;

        public RoleController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> SaveRole(string name, string description)
        {
            var usuario = "Admin";

            var role = new Role
            {
                Name = name,
                Description = description,
                RegisterDate = DateTime.Now,
                RegisterUser = usuario,
                Active = true
            };
            context.Add(role);
            await context.SaveChangesAsync();

            return View();
        }
    }
}
