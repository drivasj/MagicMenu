using Microsoft.AspNetCore.Mvc;
using DigitalMenu.Models.EntityAdministrator;
using TestWeb;
using DigitalMenu.Services.Interfaces;
using DigitalMenu.Models.DTO.UserEmployee;
using Microsoft.EntityFrameworkCore;
using DigitalMenu.Models.Entity;


namespace DigitalMenu.Controllers
{
    public class UserAdminController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IUserRepository userRepository;
        private static readonly object _lock = new object();


        public UserAdminController(ApplicationDbContext context, IUserRepository userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
        }

        public async Task<ActionResult<List<EmployeeDTO>>> Index()
        {
            try
            {
                int usuarioId = userRepository.GetUserId();

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
                return View(employee);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View("Error", message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(UserDTO model)
        {
            try
            {
                if (await userRepository.SaveUserEmployee(model))
                {
                    return Ok(new { success = true, message = "Usuario y empleado guardados correctamente." });
                }

                return Ok(new { success = false, message = "Error al intentar completar la operación." });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = string.Concat("Error general: ", ex) });
            }
        }
    }
}
