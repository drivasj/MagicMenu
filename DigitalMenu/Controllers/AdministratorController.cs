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
            var listApplications = await administratorRepository.ListApplications();
            return View(listApplications);
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
            var listMenu = await administratorRepository.ListMenu();
            var listApplication = await administratorRepository.ListApplications();
            var lisRole = await administratorRepository.Roles();
            var listMenuSinAsingnar = await administratorRepository.ListMenuSingAsignar();

            var listViewModel = new TwoListMenuApp
            {
                Menu = listMenu,
                Application = listApplication,
                Role = lisRole,
                MenuSA = listMenuSinAsingnar
            };

            return View(listViewModel);
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

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            int usuarioId = userRepository.GetUserId();
            var listemployee = await administratorRepository.ListUser();
            var listRoles = await administratorRepository.Roles();

            var listViewModel = new CombosRoleUserViewModel
            {
                Employees = listemployee,
                Roles = listRoles
            };

            return View(listViewModel);
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

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            var roles = await administratorRepository.Roles();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewModel model)
        {
            try
            {
                if (await administratorRepository.SaveRole(model))
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
    }
}
