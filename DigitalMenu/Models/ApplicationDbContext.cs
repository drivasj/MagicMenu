using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DigitalMenu.Models;
using DigitalMenu.Models.Entity;

namespace TestWeb
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dishe> Dishes {  get; set; }
        public DbSet<DisheCategory> Dishescategory { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<RestaurantDetails> Restaurantdetails { get; set; }
        public DbSet<RestaurantEmployee> Restaurantemployee { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeDetails> Employeedetails { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()
        //        .HasOne(e => e.EmployeeDetails)
        //        .WithOne(ed => ed.Employee)
        //        .HasForeignKey<EmployeeDetails>(ed => ed.IdEmployee)
        //        .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete on Employee deletion
        //}
    }
}
