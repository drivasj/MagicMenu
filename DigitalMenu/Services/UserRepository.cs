using DigitalMenu.Models.DTO.UserEmployee;
using DigitalMenu.Models.EntityAdministrator;
using DigitalMenu.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWeb;

namespace DigitalMenu.Services
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserRepository(ApplicationDbContext context, 
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public int GetUserId()
        {
            int userId = 1;
            return userId;
        }

        public async Task<int> GetLastUserId()
        {
            int userId = 1;

            //int userId = await context.User.MaxAsync(x => x.IdUser);
            return userId;
        }

        public async Task<bool> SaveUserEmployee(UserDTO model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    //variables

                    int registerUser = GetUserId();
                    var usuario = new IdentityUser() { Email = model.Email, UserName = model.UserName};
                    string pass = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("Sistemas2024."));

                    var resultado = await userManager.CreateAsync(usuario, password: pass);

                    if (resultado.Succeeded)
                    {
                        await signInManager.SignInAsync(usuario, isPersistent: true);

                        var employee = new Employee
                        {
                            FirstName = model.FirstName,
                            MiddleName = model.MiddleName,
                            LastName = model.LastName,
                            MotherLastName = model.LastName,
                            Document = model.DocumentNR,
                            UserName = model.UserName,
                            RegisterUser = registerUser.ToString(),
                            RegisterDate = DateTime.Now.Date,
                            Active = true,
                            User = new User
                            {
                                UserName = model.UserName,
                                Password = pass,
                                RegisterDate = DateTime.Now.Date,
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
    }
}
