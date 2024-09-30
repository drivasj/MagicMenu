using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;
using DigitalMenu.Models.EntityAdministrator;
using DigitalMenu.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TestWeb;

namespace DigitalMenu.Services
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly HttpContext httpContext;

        public UserRepository(ApplicationDbContext context, 
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            httpContext = httpContextAccessor.HttpContext;

        }
        public string GetUserName()
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var Claim = httpContext.User.Claims.Where(x=>x.Type == ClaimTypes.Name).FirstOrDefault();
                var userName = Claim.Value;

                return userName;
            }
            else
            {
                throw new ApplicationException("The user is not authenticated");
            }
        }

        public async Task<bool> SaveUserEmployee(CreateUserViewModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    //variables

                    string registerUser = GetUserName();
                    var usuario = new IdentityUser() { Email = model.Email, UserName = model.UserName};
                    //string pass = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("Sistemas2024."));
                    string pass = "Sistemas2024.";

                    var resultado = await userManager.CreateAsync(usuario, password: pass);

                    if (resultado.Succeeded)
                    {
                        //await signInManager.SignInAsync(usuario, isPersistent: true);

                        var employee = new Employee
                        {
                            FirstName = model.FirstName,
                            MiddleName = model.MiddleName,
                            LastName = model.LastName,
                            MotherLastName = model.LastName,
                            Document = model.Document,
                            UserName = model.UserName,
                            RegisterUser = registerUser.ToString(),
                            RegisterDate = DateTime.Now,
                            Active = true,
                            User = new User
                            {
                                UserName = model.UserName,
                                RegisterDate = DateTime.Now,
                                RegisterUser = registerUser.ToString(),
                                IdCompany = 1,
                                Active = true,
                                roleuser = new Roleuser
                                {
                                    RoleId = model.IdRole,
                                    Active = true
                                }
                            },

                            Employeedetails = new EmployeeDetails
                            {
                                Email = model.Email,
                                Phone = model.Phone,
                                Adress = model.Adress
                            }
                        };
                        context.Add(employee);
                        await context.SaveChangesAsync();
                        transaction.Commit();
                    }                                 
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    string menssage = ex.Message;                
                }
            }
            return true;
        }

        public async Task<bool> EditUserEmployee(CreateUserViewModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var userName = GetUserName();

                    var employee = await context.Employee
                        .Include(d => d.Employeedetails)
                        .Include(u => u.User)
                        .FirstOrDefaultAsync(e => e.IdEmployee == model.IdEmployee);

                    var roleUser = await context.Roleuser.FirstOrDefaultAsync(r => r.RoleId == model.IdRole);

                    if (employee == null)
                    {
                        return false;
                    }

                    employee.FirstName = model.FirstName;
                    employee.MiddleName = model.MiddleName;
                    employee.LastName = model.LastName;
                    employee.MotherLastName = model.MotherLastName;
                    employee.Document = model.Document;
                    employee.UserName = model.UserName;
                    employee.LastUpdate = DateTime.Now;

                    employee.User.UserName = model.UserName;
                    employee.User.LastUpdate = DateTime.Now;
                    employee.User.LastUpdateUser = userName;

                    employee.Employeedetails.Email = model.Email;
                    employee.Employeedetails.Phone = model.Phone;
                    employee.Employeedetails.Adress = model.Adress;

                    roleUser.RoleId = model.IdRole;

                    await context.SaveChangesAsync();
                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    string menssage = ex.Message;
                    return false;
                }
            }            
        }

        public async Task<bool> UpdateStateUser(int idUser)
        {
            try
            {
                var employee = await context.Employee.FirstOrDefaultAsync(x => x.IdEmployee == idUser);
                var user = await context.User.FirstOrDefaultAsync(x => x.EmployeeId == idUser);

                if (employee == null || user == null) { return false; }

                bool newState = employee.Active == true ? false : true;

                employee.Active = newState;
                user.Active = newState;
                await context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public async Task<bool> UserExist(string userName)
        {
            bool existUserName = await context.User.AnyAsync(x => x.UserName.ToUpper() == userName.ToUpper());

            return existUserName;                
        }
    }
}
