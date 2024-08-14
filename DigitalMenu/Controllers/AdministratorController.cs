using DigitalMenu.Models.Administrator;
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

        public AdministratorController(ApplicationDbContext context, IAdministratorRepository administratorRepository)
        {
            this.context = context;
            this.administratorRepository = administratorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult<List<ApplicationViewModel>>> Application()
        {
            try
            {
                var application = await context.Application.Where(a => a.Active == true).Select(a => new ApplicationViewModel
                {
                    IdApplication = a.IdApplication,
                    Name = a.Name,
                    Description = a.Description,
                    Display = a.Display
                }).ToListAsync();

                return View (application);

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
    }
}
