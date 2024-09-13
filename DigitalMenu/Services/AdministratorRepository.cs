using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;
using DigitalMenu.Models.EntityAdministrator;
using DigitalMenu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using TestWeb;

namespace DigitalMenu.Services
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly ApplicationDbContext context;

        public AdministratorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<MenuViewModel>> ListMenu()
        {
            try
            {
                var menu = await context.Menu
                    .Include(a => a.application)
                    //.Where(m => m.Active == true)
                    .Select(m => new MenuViewModel
                    {
                        IdMenu = m.IdMenu,
                        ApplicationName = m.application.Display,
                        Name = m.Name,
                        Active = m.Active

                    }).ToListAsync();

                return menu;
            }
            catch (Exception ex)
            {
                string menssage = ex.Message;
                return null;
            }
        }

        public async Task<List<MenuSelect>> ListMenuSingAsignar(int idRol)
        {
            try
            {
                var menu = await context.Menu
                    .Where(m => !m.rolemenu.Any(rm => rm.RoleId == idRol))
                    .Select(m => new MenuSelect
                    {
                        IdMenu = m.IdMenu,
                        Name = m.Name,

                    }).ToListAsync();

                return menu;
            }
            catch (Exception ex)
            {
                string menssage = ex.Message;
                return null;
            }
        }

        public async Task<bool> SaveMenu(MenuViewModel model)
        {
            try
            {
                var menu = new Menu
                {
                    ApplicationId = model.ApplicationId,
                    Area = model.Area,
                    Controller = model.Controller,
                    Action = model.Action,
                    Name = model.Name = model.Name,
                    Movil = false,
                    Description = model.Description,
                    RegisterDate = DateTime.Now,
                    RegisterUser = "1",
                    Active = true
                };

                context.Add(menu);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string menssage = ex.Message;
                return false;
            }
        }

        public async Task<bool> Rolemenu(RoleMenuViewModel model)
        {
            try
            {
                var rolMenu = new Rolemenu
                {
                    RoleId = model.RoleId,
                    MenuId = model.MenuId,
                    Active = true
                };

                context.Add(rolMenu);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string menssage = ex.Message;
                return false;
            }
        }

        public async Task<List<ApplicationViewModel>> ListApplications()
        {
            try
            {
                var application = await context.Application.Where(a => a.Active == true).Select(a => new ApplicationViewModel
                {
                    IdApplication = a.IdApplication,
                    Name = a.Name,
                    Description = a.Description,
                    Display = a.Display,
                    Icon = a.Icon
                }).ToListAsync();

                return application;
            }
            catch (Exception ex)
            {
                string menssage = ex.Message;
                return null;
            }
        }

        public async Task<bool> SaveApplication(ApplicationViewModel model)
        {
            try
            {
                var application = new Application
                {
                    Name = model.Name,
                    Description = model.Description,
                    RegisterDate = DateTime.Now,
                    RegisterUser = "1",
                    Active = true,
                    Display = model.Display,
                    Icon = model.Icon,
                };

                context.Add(application);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string menssage = ex.Message;
                return false;
            }
        }

        public async Task<List<EmployeeDTO>> ListUser()
        {
            try
            {
                var employee = await context.Employee
                //.Include(e=>e.Employeedetails)
                .Where(e => e.Active == true)
                .OrderByDescending(e => e.IdEmployee)
                .Select(t => new EmployeeDTO
                {
                    IdEmployee = t.IdEmployee,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    UserName = t.UserName,
                    Email = t.Employeedetails.Email
                }).ToListAsync();

                return employee;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<EmployeeDTO> _getDetailUser(int idUser)
        {
            var employee = await context.Employee.Where(x =>x.IdEmployee == idUser).Select(e => new EmployeeDTO
            {
                IdEmployee = e.IdEmployee,
                FirstName = e.FirstName,
                LastName = e.LastName,
                UserName = e.UserName,
                Email = e.Employeedetails.Email
            }).FirstOrDefaultAsync();

            return employee;
        }

        public async Task<List<RoleViewModel>> Roles()
        {
            try
            {
                var roles = await context.Role
                .Select(r => new RoleViewModel
                {
                    IdRole = r.IdRole,
                    Name = r.Name,
                    Description = r.Description,
                    Active = r.Active
                }).ToListAsync();
                return roles;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<bool> SaveRole(RoleViewModel model)
        {
            try
            {
                var role = new Role
                {
                    Name = model.Name,
                    Description = model.Description,
                    Privilege = 0,
                    RegisterDate = DateTime.Now,
                    RegisterUser = "1",
                    Active = true
                };

                context.Add(role);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string menssage = ex.Message;
                return false;
            }
        }
    }
}
