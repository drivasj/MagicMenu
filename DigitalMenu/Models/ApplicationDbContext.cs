using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DigitalMenu.Models;
using DigitalMenu.Models.Entity;

namespace TestWeb
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dishes> Dishes {  get; set; }
        public DbSet<DishesCategory> DishesCategory { get; set; }
    }
}
