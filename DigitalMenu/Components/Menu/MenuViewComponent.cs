using DigitalMenu.Models;
using DigitalMenu.Models.EntityAdministrator;
using Microsoft.AspNetCore.Mvc;
using TestWeb;

namespace DigitalMenu.Components.Menu
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext context;

        public MenuViewComponent(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                int idUser = 1;
                var menu = _getMenu(idUser);
                return View(menu);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View(message);
            }
        }

        private List<MenuCLS> _getMenu(int idUser)
        {
            List<MenuCLS> menu;

            menu = (from ru in context.Roleuser
                    join u in context.User on ru.UserId equals u.IdUser
                    join r in context.Role on ru.RoleId equals r.IdRole
                    join rm in context.Rolemenu on r.IdRole equals rm.RoleId
                    join m in context.Menu on rm.MenuId equals m.IdMenu
                    join a in context.Application on m.ApplicationId equals a.IdApplication
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

            return menu.GroupBy(x => x.nameMenu).Select(x => new MenuCLS()
            {
                nameMenu = x.Key,
                icon = x.FirstOrDefault().icon,
                movil = x.Where(a => a.movil == true).Select(a => a.movil).FirstOrDefault(),
                elements = x.Select(a => new SubMenu()
                {
                    action = a.action,
                    area = a.area,
                    controller = a.controller,
                    display = a.display,
                    movil = a.movil
                }).ToList()
            }).OrderBy(x => x.nameMenu).ToList();
        }
    }
}
