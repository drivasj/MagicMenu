using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;
using DigitalMenu.Services;
using DigitalMenu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWeb;

namespace DigitalMenu.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IAdministratorRepository administratorRepository;
        private readonly IUserRepository userRepository;

        public AdministratorController(ApplicationDbContext context, 
            IAdministratorRepository administratorRepository,
            IUserRepository userRepository)
        {
            this.context = context;
            this.administratorRepository = administratorRepository;
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Application()
        {
            try
            {
                var listApplications = await administratorRepository.ListApplications();
                return View (listApplications);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View("Error", message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveApplication(ApplicationViewModel model)
        {
            try
            {
                if (await administratorRepository.SaveApplication(model))
                {
                    return Ok(new { success = true, message = "Registro guardado correctamente." });
                }

                return Ok(new { success = false, message = "Error al intentar completar la operación." });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = string.Concat("Error general: ", ex) });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Menu()
        {
            try
            {
                var listMenu = await administratorRepository.ListMenu();
                return View(listMenu);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View("Error", message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveMenu(MenuViewModel model)
        {
            try
            {
                if (await administratorRepository.SaveMenu(model))
                {
                    return Ok(new { success = true, message = "Registro guardado correctamente." });
                }

                return Ok(new { success = false, message = "Error al intentar completar la operación." });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = string.Concat("Error general: ", ex) });
            }
        }

        public async Task<ActionResult<List<EmployeeDTO>>> User()
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
