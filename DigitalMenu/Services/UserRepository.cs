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

        public async Task<bool> SaveUserEmployee(UserDTO model)
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
                            Document = model.DocumentNR,
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

        public async Task<bool> EditUserEmployee(UserDTO model)
        {
            try
            {
                var employee = await context.Employee.Include(d=>d.Employeedetails).FirstOrDefaultAsync(e=>e.IdEmployee == model.IdEmployee);

                if (employee == null)
                {
                    return false;
                }

                employee.FirstName = model.FirstName;
                employee.MiddleName = model.MiddleName;
                employee.UserName = model.UserName;
                employee.Employeedetails.Email = model.Email;
                employee.LastUpdate = DateTime.Now;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string menssage = ex.Message;
                return false;
            }
        }

        public async Task<bool> UpdateStateUser(int idUser)
        {
            try
            {
                var user = await context.Employee.FirstOrDefaultAsync(x => x.IdEmployee == idUser);

                if (user == null) { return false; }

                bool newState = user.Active == true ? false : true;

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
    }
}
