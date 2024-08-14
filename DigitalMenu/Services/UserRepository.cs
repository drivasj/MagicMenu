using DigitalMenu.Models.DTO.UserEmployee;
using DigitalMenu.Models.EntityAdministrator;
using DigitalMenu.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestWeb;

namespace DigitalMenu.Services
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
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
                    int iduser = GetUserId();

                    var employee = new Employee
                    {
                        FirstName = model.FirstName,
                        MiddleName = model.MiddleName,
                        LastName = model.LastName,
                        MotherLastName = model.LastName,
                        Document = model.DocumentNR,
                        UserName = model.UserName,
                        RegisterUser = iduser.ToString(),
                        RegisterDate = DateTime.Now.Date,
                        Active = true,
                        User = new User
                        {
                            UserName = model.UserName,
                            Password = "12345678",
                            RegisterDate = DateTime.Now.Date,
                            RegisterUser = iduser.ToString(),
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
