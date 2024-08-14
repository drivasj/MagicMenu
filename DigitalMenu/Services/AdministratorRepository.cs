using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;
using DigitalMenu.Models.EntityAdministrator;
using DigitalMenu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWeb;

namespace DigitalMenu.Services
{
    public class AdministratorRepository: IAdministratorRepository
    {
        private readonly ApplicationDbContext context;

        public AdministratorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<MenuViewModel>> ListMenu()
        {
            var menu = await context.Menu.Where(m => m.Active == true).Select(m => new MenuViewModel
            {
                IdMenu = m.IdMenu,
                ApplicationId = m.ApplicationId,
                Controller = m.Controller,
                Action = m.Action,
                Name = m.Name,
                Active = m.Active

            }).ToListAsync();

            return menu;
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

        public async Task<List<ApplicationViewModel>> ListApplications()
        {        
            var application = await context.Application.Where(a => a.Active == true).Select(a => new ApplicationViewModel
            {
                IdApplication = a.IdApplication,
                Name = a.Name,
                Description = a.Description,
                Display = a.Display
            }).ToListAsync();

            return application;
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

        public async Task<ActionResult<List<EmployeeDTO>>> ListUser()
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
    }
}
