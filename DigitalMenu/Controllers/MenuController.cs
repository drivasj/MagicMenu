using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.EntityAdministrator;
using Microsoft.AspNetCore.Mvc;
using TestWeb;

namespace DigitalMenu.Controllers
{
    public class MenuController : Controller
    {
        public ApplicationDbContext Context { get; }

        public MenuController(ApplicationDbContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateMenu()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveMenu(MenuViewModel model)
        {
            try
            {
                var menu = new Menu
                {
                    IdApplication = model.IdApplication,
                    Area = model.Area,
                    Controller = model.Controller,
                    Action = model.Action,
                    Name = model.Name = model.Name,
                    Description = model.Description
                };

                Context.Add(menu);
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
