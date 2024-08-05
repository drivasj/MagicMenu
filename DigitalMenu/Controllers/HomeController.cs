using DigitalMenu.Models;
using DigitalMenu.Models.EntityAdministrator;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWeb;

namespace DigitalMenu.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ApplicationDbContext context)
        {
            Context = context;
        }
        private readonly ILogger<HomeController> _logger;

        public ApplicationDbContext Context { get; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult LoadMenu()
        {
            int idUser = 1;

            return PartialView("_Menu", _getMenu(idUser));
        }

        private List<MenuCLS> _getMenu(int idUser)
        {
            List<MenuCLS> menu;

            menu = (from ru in Context.Roleuser
                    join u in Context.User on ru.IdUser equals u.IdUser
                    join r in Context.Role on ru.IdRole equals r.IdRole
                    join rm in Context.Rolemenu on r.IdRole equals rm.IdRole
                    join m in Context.Menu on rm.IdMenu equals m.IdMenu
                    join a in Context.Application on m.IdApplication equals a.IdApplication
                    where u.IdUser == idUser && ru.Active == true && rm.Active == true
                    select new MenuCLS()
                    {
                        nameMenu = a.Display,
                        display = m.Name,
                        area = m.Area,
                        controller = m.Controller,
                        action = m.Action,
                        movil = m.Movil,
                        icon = a.Icon
                    }).OrderBy(x => x.display).ToList();

            return menu;
        }
    }
}
