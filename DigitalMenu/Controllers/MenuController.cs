﻿using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.DTO.UserEmployee;
using DigitalMenu.Models.EntityAdministrator;
using DigitalMenu.Services;
using DigitalMenu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWeb;

namespace DigitalMenu.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IAdministratorRepository administratorRepository;

        public MenuController(ApplicationDbContext context, IAdministratorRepository administratorRepository)
        {
            this.context = context;
            this.administratorRepository = administratorRepository;
        }
        public async Task<ActionResult<List<MenuViewModel>>> Index()
        {
            try
            {
                var menu = await context.Menu.Where(m => m.Active == true).Select(m => new MenuViewModel
                {
                    IdMenu = m.IdMenu,
                    ApplicationId = m.ApplicationId,
                    Controller = m.Controller,
                    Action = m.Action,
                    Name = m.Name,
                    Active = m.Active

                }).ToListAsync();

                return View(menu);
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
    }
}
