using DigitalMenu.Models.EntityAdministrator;
using Microsoft.AspNetCore.Mvc;
using TestWeb;

namespace DigitalMenu.Models.Administrator
{
    public class ApplicationController : Controller
    {
        public ApplicationDbContext Context { get; }

        public ApplicationController(ApplicationDbContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateApp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveApp(ApplicationViewModel model)
        {
            try
            {
                var app = new Application
                {
                    Name = model.Name,
                    Description = model.Description,
                    Display = model.Display,
                    Icon = model.Icon,
                    RegisterDate = DateTime.Now,
                    RegisterUser = "Admin",
                    Active = true
                };

                Context.Add(app);
                await Context.SaveChangesAsync();
                return View();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View(message);
            }
        }

    }
}
