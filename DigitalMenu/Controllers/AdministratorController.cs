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

        public async Task<IActionResult> Application()
        {
            string userName = userRepository.GetUserName();

            if (userName == null)
            {
                return BadRequest();
            }

            var listApplications = await administratorRepository.ListApplications();
            return View(listApplications);
        }

        [HttpPost]
        public async Task<IActionResult> ShowDetailApplication(int idApp)
        {
            var app = await administratorRepository._getDetailApp(idApp);
            return PartialView("~/Views/Administrator/_Partial/_DetailApplicationForm.cshtml", app);
        }

        [HttpPost]
        public IActionResult ShowCreateApplication()
        {
            return PartialView("~/Views/Administrator/_Partial/_CreateApplicationForm.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> EditApp([FromBody] ApplicationViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                    return Json(new { success = false, message = errors });
                }

                var app = await administratorRepository.EditApp(model);

                return Json(new
                {
                    success = app,
                    message = app ? "Registro actualizado correctamente." : "Error al intentar completar la opración."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStateApp([FromBody] ApplicationViewModel model)
        {
            try
            {
                var app = await administratorRepository.UpdateStateApp(model.IdApplication);
                return Json(new
                {
                    success = app,
                    message = app ? "Registro actualizado correctamente." : "Error al intentar completar la operación"
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveApplication([FromBody] ApplicationViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
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
                return Json(new { success = false, message = string.Concat("Error general: ", ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ShowCreateMenu(CreateMenuViewModel model)
        {
            try
            {
                var listApplication =  await administratorRepository.ListApplications();

                model.Application = listApplication;

                return PartialView("~/Views/Administrator/_Partial/_CreateMenuForm.cshtml", model);
            }
            catch (Exception ex) 
            {
                string message = ex.Message;
                return PartialView("~/Views/Administrator/_Partial/_CreateMenuForm.cshtml");

            }
        }

        [HttpPost]
        public async Task<IActionResult> ShowDetailMenu(int idMenu)
        {
            var menu = await administratorRepository._getDetailMenu(idMenu);
            return PartialView("~/Views/Administrator/_Partial/_DetailMenuForm.cshtml", menu);
        }

        [HttpPost]
        public async Task<IActionResult> EditMenu([FromBody] CreateMenuViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || model.ApplicationId <= 0)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
                }

                var menu = await administratorRepository.Editmenu(model);

                return Json(new
                {
                    success = menu,
                    message = menu ? "Registro actualizado correctamente." : "Error al intentar completar la opración."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
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
                    return Json(new { success = false, message = "Debe seleccionar un rol y un menu para continuar" });
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
        public async Task<IActionResult> SaveMenu([FromBody] CreateMenuViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || model.ApplicationId <= 0)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
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

        [HttpPost]
        public async Task<IActionResult> UpdateStateMenu([FromBody] MenuViewModel model)
        {
            try
            {
                var app = await administratorRepository.UpdateStateMenu(model.IdMenu);
                return Json(new
                {
                    success = app,
                    message = app ? "Registro actualizado correctamente." : "Error al intentar completar la operación"
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
            string userName = userRepository.GetUserName();
            var listemployee = await administratorRepository.ListUser();
            var listRoles = await administratorRepository.Roles();

            var listViewModel = new CreateUserViewModel
            {
                Employees = listemployee,
                Roles = listRoles

            };

            return View("Users", listViewModel);
        }

        [HttpPost]
        public async Task <IActionResult> ShowCreateUser()
        {
            var listemployee = await administratorRepository.ListUser();
            var listRoles = await administratorRepository.Roles();

            var listViewModel = new CreateUserViewModel
            {
                Employees = listemployee,
                Roles = listRoles
            };

            return PartialView("~/Views/Administrator/_Partial/_CreateUserForm.cshtml", listViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ShowDetailUser(int idUser)
        {
            try
            {
                var user = await administratorRepository._getDetailUser(idUser);

                return PartialView("~/Views/Administrator/_Partial/_DetailUserForm.cshtml", user);
            }
            catch (Exception ex) 
            {
                return PartialView("~/Views/Administrator/_Partial/_DetailUserForm.cshtml");
            }

        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] CreateUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
                }

                if (await userRepository.UserExist(model.UserName)) throw new ApplicationException("El nombre de usuario ya existe.");

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

        [HttpPost]
        public async Task<IActionResult> UpdateStateUser([FromBody] UserDTO model)
        {
            try
            {
                var app = await userRepository.UpdateStateUser(model.IdEmployee);
                return Json(new
                {
                    success = app,
                    message = app ? "Registro actualizado correctamente." : "Error al intentar completar la operación"
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUser([FromBody] CreateUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
                }

                var user = await userRepository.EditUserEmployee(model);

                return Json(new
                {
                    success = user,
                    message = user ? "Registro actulizado correctamente." : "Error al intentar completar la operación."
                });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ShowDetailRol(int idRol)
        {
            var rol = await administratorRepository._getDetailRole(idRol);
            return PartialView("~/Views/Administrator/_Partial/_DetailRolForm.cshtml", rol);
        }

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            var roles = await administratorRepository.Roles();
            return View(roles);
        }


        [HttpPost]
        public IActionResult ShowCreateRole()
        {
            return PartialView("~/Views/Administrator/_Partial/_CreateRolForm.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole([FromBody] RoleViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
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

        [HttpPost]
        public async Task<IActionResult> EditRole([FromBody] RoleViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || model.IdRole <= 0)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
                }

                var menu = await administratorRepository.EditRole(model);

                return Json(new
                {
                    success = menu,
                    message = menu ? "Registro actualizado correctamente." : "Error al intentar completar la opración."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStateRole([FromBody] RoleViewModel model)
        {
            try
            {
                var app = await administratorRepository.UpdateStateRole(model.IdRole);
                return Json(new
                {
                    success = app,
                    message = app ? "Registro actualizado correctamente." : "Error al intentar completar la operación"
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

        //systemVariable
        public async Task<IActionResult> SystemVariable()
        {
            var variables = await administratorRepository.ListSystemVariables();
            return View(variables);
        }

        [HttpPost]
        public async Task<IActionResult> ShowCreateVariable(SystemvariableViewModel model)
        {
            var listType = await administratorRepository.ListTypesyStemvariable();
            model.Typesystemvariable = listType;
            return PartialView("~/Views/Administrator/_Partial/_CreateVariableForm.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveVariable([FromBody] SystemvariableViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
                }

                var variable = await administratorRepository.SaveVariable(model);

                return Json(new
                {
                    success = variable,
                    message = variable ? "Registro guardado correctamente." : "Error al intentar completar la operación."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ShowDetailVariable(int idVariable)
        {
            var variables = await administratorRepository._getDetailSystemvariable(idVariable);

            return PartialView("~/Views/Administrator/_Partial/_DetailVariableForm.cshtml", variables);
        }

        [HttpPost]
        public async Task<IActionResult> EditVariable([FromBody] SystemvariableViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
                }

                var variable = await administratorRepository.EditVariable(model);

                return Json(new
                {
                    success = variable,
                    message = variable ? "Registro actualizado correctamente." : "Error al intentar completar la opración."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStateVariable([FromBody] SystemvariableViewModel model)
        {
            try
            {
                var app = await administratorRepository.UpdateStateVariable(model.IdSystemVariable);
                return Json(new
                {
                    success = app,
                    message = app ? "Registro actualizado correctamente." : "Error al intentar completar la operación"
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
