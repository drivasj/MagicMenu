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
        public async Task<ActionResult<Role>> SaveRole([FromBody] RoleCrearDTO roleCrearDTO)
        {
            var usuario = "Admin";

            var role = new Role
            {
                Name = roleCrearDTO.Name,
                Description = roleCrearDTO.Description,
                RegisterDate = DateTime.Now,
                RegisterUser = usuario,
                Active = true
            };
            context.Add(role);
            await context.SaveChangesAsync();

            return role;
        }
    }
}
