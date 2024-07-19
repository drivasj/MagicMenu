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

        public DbSet<Dishe> Dishes {  get; set; }
        public DbSet<DisheCategory> Dishescategory { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<RestaurantDetails> Restaurantdetails { get; set; }
        public DbSet<RestaurantEmployee> RestaurantEmployee { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

    }
}
