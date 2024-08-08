using Microsoft.AspNetCore.Mvc;
using DigitalMenu.Models.EntityAdministrator;
using TestWeb;
using DigitalMenu.Services.Interfaces;
using DigitalMenu.Models.DTO.UserEmployee;
using Microsoft.EntityFrameworkCore;


namespace DigitalMenu.Controllers
{
    public class UserAdminController : Controller
    {
        private readonly IUserRepository userRepository;

        public ApplicationDbContext Context { get; }

        public UserAdminController(ApplicationDbContext context, IUserRepository userRepository)
        {
            Context = context;
            this.userRepository = userRepository;
        }

        public async Task<ActionResult<List<EmployeeDTO>>> Index()
        {
            int usuarioId = userRepository.GetUserId();

            var employee = await Context.Employee
                            .Where(e => e.Active == true)
                            .OrderByDescending(e => e.IdEmployee)
                            .Select(t => new EmployeeDTO
                            {
                                IdEmployee = t.IdEmployee,
                                FirstName = t.FirstName,
                                LastName = t.LastName,
                                UserName = t.UserName
                            }).ToListAsync();
            return View(employee); 
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> SaveUser(string userName, string password)
        {
            var registerUser = "Admin";

            var user = new User
            {
                UserName = userName,
                Password = password,
                IdEmployee = 1,
                RegisterDate = DateTime.Now,
                RegisterUser = registerUser,
                IdCompany = 1,
                Active = true
            };

            Context.Add(user);
            await Context.SaveChangesAsync();
            return View();
        }
    }
}
