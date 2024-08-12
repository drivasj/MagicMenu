﻿using Microsoft.AspNetCore.Mvc;
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
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int iduser = userRepository.GetUserId();

                    int iduserNew = await userRepository.GetLastUserId() +1;

                    var user = new User
                    {
                        UserName = model.UserName,
                        Password = "12345678",
                        IdEmployee = model.IdEmployee,
                        RegisterDate = DateTime.Now.Date,
                        IdCompany = 1,
                        Active = true,
                    };

                    var employee = new Employee
                    {
                        Code = iduserNew,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Document = model.DocumentNR,
                        UserName = model.UserName,
                        RegisterUser = iduser.ToString(),
                        RegisterDate = DateTime.Now.Date,
                        Active = true,
                    };

                    var employeeDetails = new EmployeeDetails
                    {
                        Email = model.Email,
                        Phone = model.Phone,
                        Adress = model.Adress
                    };

                    var roleuser = new Roleuser
                    {
                        IdRole = model.IdRole,
                        IdUser = iduserNew,
                        Active = true
                    };

                    context.Add(user);
                    context.Add(employee);
                    context.Add(employee);
                    context.Add(roleuser);

                    await context.SaveChangesAsync();
                    transaction.Commit();

                    return View();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    string menssage = ex.Message;
                    return View(menssage);
                }
            }
        }
    }
}
