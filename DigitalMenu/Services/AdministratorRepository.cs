using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;
using DigitalMenu.Models.EntityAdministrator;
using DigitalMenu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using TestWeb;

namespace DigitalMenu.Services
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IUserRepository userRepository;

        public AdministratorRepository(ApplicationDbContext context, IUserRepository userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
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
                string message = ex.Message;
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
                string message = ex.Message;
                return null;
            }
        }

        public async Task<CreateMenuViewModel> _getDetailMenu(int idMenu)
        {
            var listApplication = await ListApplications();

            var menu = await context.Menu.Where(x => x.IdMenu == idMenu).Select(m => new CreateMenuViewModel
            {
                IdMenu = m.IdMenu,
                ApplicationId = m.ApplicationId,
                Area = m.Area,
                Controller = m.Controller,
                Action = m.Action,
                Name = m.Name,
                Description = m.Description,
                Application = listApplication
            }).FirstOrDefaultAsync();

            return menu;
        }

        public async Task<bool> Editmenu(CreateMenuViewModel model)
        {
            try
            {
                var userName = userRepository.GetUserName();
                var menu = await context.Menu.FirstOrDefaultAsync(x => x.IdMenu == model.IdMenu);

                if (menu == null)
                {
                    return false;
                }
                menu.ApplicationId = model.ApplicationId;
                menu.Name = model.Name;
                menu.Area = model.Area;
                menu.Controller = model.Controller;
                menu.Action = model.Action;
                menu.Description = model.Description;
                menu.LastUpdate = DateTime.Now;
                menu.LastUpdateUser = userName;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public async Task<bool> SaveMenu(MenuViewModel model)
        {
            try
            {
                var userName = userRepository.GetUserName();

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
                    RegisterUser = userName,
                    Active = true
                };

                context.Add(menu);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public async Task<bool> UpdateStateMenu(int idMenu)
        {
            try
            {
                var menu = await context.Menu.FirstOrDefaultAsync(x => x.IdMenu == idMenu);

                if (menu == null) { return false; }

                bool newState = menu.Active == true ? false : true;

                menu.Active = newState;
                await context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
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
                string message = ex.Message;
                return false;
            }
        }

        public async Task<ApplicationViewModel> _getDetailApp(int idApp)
        {
            var app = await context.Application.Where(x => x.IdApplication == idApp).Select(a => new ApplicationViewModel
            {
                IdApplication = a.IdApplication,
                Name = a.Name,
                Description = a.Description,
                Display = a.Display,
                Icon = a.Icon
            }).FirstOrDefaultAsync();

            return app;
        }

        public async Task<List<ApplicationViewModel>> ListApplications()
        {
            try
            {
                var application = await context.Application.Select(a => new ApplicationViewModel
                {
                    IdApplication = a.IdApplication,
                    Name = a.Name,
                    Description = a.Description,
                    Display = a.Display,
                    Icon = a.Icon,
                    Active = a.Active
                }).ToListAsync();

                return application;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<bool> EditApp(ApplicationViewModel model)
        {
            try
            {
                var userName = userRepository.GetUserName();
                var app = await context.Application.FirstOrDefaultAsync(x => x.IdApplication == model.IdApplication);

                if (app == null)
                {
                    return false;
                }

                app.Name = model.Name;
                app.Description = model.Description;
                app.Display = model.Display;
                app.Icon = model.Icon;
                app.LastUpdate = DateTime.Now;
                app.LastUpdateUser = userName;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public async Task<bool> UpdateStateApp(int idApplication)
        {
            try
            {
                var app = await context.Application.FirstOrDefaultAsync(x => x.IdApplication == idApplication);

                if (app == null) { return false; }

                bool newState = app.Active == true ? false : true;

                app.Active = newState;
                await context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
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
                string message = ex.Message;
                return false;
            }
        }

        public async Task<List<EmployeeDTO>> ListUser()
        {
            try
            {
                var employee = await context.Employee
                //.Include(e=>e.Employeedetails)
                //.Where(e => e.Active == true)
                .OrderByDescending(e => e.IdEmployee)
                .Select(t => new EmployeeDTO
                {
                    IdEmployee = t.IdEmployee,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    UserName = t.UserName,
                    Active= t.Active,
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

        public async Task<CreateUserViewModel> _getDetailUser(int idEmployee)
        {
            var listRoles = await Roles();
            var idrole = await context.Roleuser.Where(x => x.UserId == idEmployee).Select(x => x.RoleId).FirstOrDefaultAsync();

            var employee = await context.Employee.Where(x => x.IdEmployee == idEmployee).Select(e => new CreateUserViewModel
            {
                IdEmployee = e.IdEmployee,
                FirstName = e.FirstName,
                MiddleName = e.MiddleName,
                LastName = e.LastName,
                MotherLastName = e.MotherLastName,
                Document = e.Document,
                UserName = e.UserName,
                Email = e.Employeedetails.Email,
                Phone = e.Employeedetails.Phone,
                Adress = e.Employeedetails.Adress,
                IdRole = idrole,
                Roles = listRoles

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

        public async Task<RoleViewModel> _getDetailRole(int idRole)
        {

            var role = await context.Role.Where(x => x.IdRole == idRole).Select(m => new RoleViewModel
            {
                IdRole = m.IdRole,
                Name = m.Name,
                Description = m.Description

            }).FirstOrDefaultAsync();

            return role;
        }

        public async Task<bool> EditRole(RoleViewModel model)
        {
            try
            {
                var userName = userRepository.GetUserName();
                var role = await context.Role.FirstOrDefaultAsync(x => x.IdRole == model.IdRole);

                if (role == null)
                {
                    return false;
                }

                role.IdRole = model.IdRole;
                role.Name = model.Name;
                role.Description = model.Description;
                role.LastUpdate = DateTime.Now;
                role.LastUpdateUser = userName;

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public async Task<bool> SaveRole(RoleViewModel model)
        {
            try
            {
                var userName = userRepository.GetUserName();
                var role = new Role
                {
                    Name = model.Name,
                    Description = model.Description,
                    Privilege = 0,
                    RegisterDate = DateTime.Now,
                    RegisterUser = userName,
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

        public async Task<bool> UpdateStateRole(int idRole)
        {
            try
            {
                var role = await context.Role.FirstOrDefaultAsync(x => x.IdRole == idRole);

                if (role == null) { return false; }

                bool newState = role.Active == true ? false : true;

                role.Active = newState;
                await context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        //SystemVariables

        public async Task<List<SystemvariableViewModel>> ListSystemVariables()
        {
            try
            {
                var variables = await context.Systemvariable.Select(s => new SystemvariableViewModel
                {
                    IdSystemVariable = s.IdSystemVariable,
                    Name = s.Name,
                    Description = s.Description,
                    ValueNumeric = s.ValueNumeric,
                    ValueString = s.ValueString,
                    Active = s.Active
                }).ToListAsync();
                return variables;
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<bool> SaveVariable(SystemvariableViewModel model)
        {
            try
            {
                var userName = userRepository.GetUserName();

                var variable = new Systemvariable
                {
                    IdSystemVariable = model.IdSystemVariable,               
                    Name = model.Name = model.Name,               
                    Description = model.Description,
                    ValueNumeric = model.ValueNumeric,
                    ValueString= model.ValueString,
                    IdCompany = 1,
                    RegisterDate = DateTime.Now,
                    RegisterUser = userName,
                    Active = true
                };

                context.Add(variable);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public async Task<bool> EditVariable(SystemvariableViewModel model)
        {
            try
            {
                var userName = userRepository.GetUserName();
                var variable = await context.Systemvariable.FirstOrDefaultAsync(x => x.IdSystemVariable == model.IdSystemVariable);

                if (variable == null)
                {
                    return false;
                }
                variable.TypesystemvariableId = model.TypesystemvariableId;
                variable.IdCompany =1;
                variable.Name = model.Name;
                variable.Description = model.Description;
                variable.ValueNumeric = model.ValueNumeric;
                variable.ValueString = model.ValueString;
                variable.LastUpdate = DateTime.Now;
                variable.LastUpdateUser = userName;

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public async Task<List<TypesystemvariableViewModel>> ListTypesyStemvariable()
        {
            try
            {
                var type = await context.Typesystemvariable.Select(t => new TypesystemvariableViewModel
                {
                    IdTypesystemvariable = t.IdTypesystemvariable,
                    Name = t.Name,
                    Description = t.Description,                 
                    Active = t.Active
                }).ToListAsync();

                return type;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }
    }
}
