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

       
    }
}
