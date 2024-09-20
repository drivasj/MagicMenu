﻿using DigitalMenu.Models;
using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;
using DigitalMenu.Models.EntityAdministrator;
using DigitalMenu.Services;
using DigitalMenu.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWeb;
using ZstdSharp.Unsafe;

namespace DigitalMenu.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IAdministratorRepository administratorRepository;
        private readonly IUserRepository userRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AdministratorController(ApplicationDbContext context,
            IAdministratorRepository administratorRepository,
            IUserRepository userRepository,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.administratorRepository = administratorRepository;
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
        public async Task<IActionResult> SaveApplication([FromBody] ApplicationViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Model");
                }

                var app = await administratorRepository.SaveApplication(model);

                return Json(new
                {
                    success = app,
                    message = app ? "Registro guardado correctamente." : "Error al intentar completar la operación."
                });

            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = string.Concat("Error general: ", ex) });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Menu()
        {
            var listApplication = await administratorRepository.ListApplications();
            var lisRole = await administratorRepository.Roles();
            var listMenu = await administratorRepository.ListMenu();

            var listViewModel = new TwoListMenuApp
            {
                Application = listApplication,
                Role = lisRole,
                Menu = listMenu
            };

            return View(listViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetMenuRol([FromBody] TestModel model)
        {
            if (model.rolId == 0)
            {
                return BadRequest("Invalid role ID");
            }

            var menus = await administratorRepository.ListMenuSingAsignar(model.rolId);

            return Json(menus);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMenuRol([FromBody] RoleMenuViewModel model)
        {
            try
            {
                if (model.RoleId == 0 || model.MenuId == 0)
                {
                    return BadRequest("Invalid role ID");
                }

                var roleMenu = await administratorRepository.Rolemenu(model);

                return Json(new
                {
                    success = roleMenu,
                    message = roleMenu ? "Registro guardado correctamente." : "Error al intentar completar la operación."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveMenu([FromBody] MenuViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Model");
                }

                var menu = await administratorRepository.SaveMenu(model);

                return Json(new
                {
                    success = menu,
                    message = menu ? "Registro guardado correctamente." : "Error al intentar completar la operación."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
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

            return View("Users", listViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ShowDetailUser(int idUser)
        {
            var user = await administratorRepository._getDetailUser(idUser);
            return PartialView("~/Views/Administrator/_Partial/_DetailUser.cshtml", user);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] UserDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Model");
                }

                var user = await userRepository.SaveUserEmployee(model);

                return Json(new
                {
                    success = user,
                    message = user ? "Registro guardado correctamente." : "Error al intentar completar la operación."
                });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            var roles = await administratorRepository.Roles();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole([FromBody] RoleViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Model");
                }

                var rol = await administratorRepository.SaveRole(model);

                return Json(new
                {
                    success = rol,
                    message = rol ? "Registro guardado correctamente." : "Error al intentar completar la operación."
                });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Login(string mensaje = null)
        {
            if (mensaje is not null)
            {
                ViewData["mensaje"] = mensaje;
            }

            return View();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var resultado = await signInManager.PasswordSignInAsync(modelo.User, modelo.Password, modelo.Recuerdame, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o password incorrecto");
                return View(modelo);
            }
        }

        /// <summary>
        /// logout
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// HacerAdmin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> HacerAdmin(string user)
        {
            try
            {
                var usuario = await context.Users.Where(u => u.UserName == user).FirstOrDefaultAsync();

                if (usuario is null)
                {
                    return NotFound();
                }

                await userManager.AddToRoleAsync(usuario, Constantes.RolAdmin);


                return Json(new { success = true, message = "Registro guardado correctamente." });

                //if (model.RoleId == 0 || model.MenuId == 0)
                //{
                //    return BadRequest("Invalid role ID");
                //}

                //var roleMenu = await administratorRepository.Rolemenu(model);

                //if(usuario is success)

                //return Json(new
                //{
                //    success = usuario,
                //    message = usuario ? "Registro guardado correctamente." : "Error al intentar completar la operación."
                //});
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Remover Admin
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = Constantes.RolAdmin)]
        public async Task<IActionResult> RemoverAdmin(string userName)
        {
            var usuario = await context.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();

            if (usuario is null)
            {
                return NotFound();
            }

            await userManager.RemoveFromRoleAsync(usuario, Constantes.RolAdmin);

            return View();
        }
    }
}
