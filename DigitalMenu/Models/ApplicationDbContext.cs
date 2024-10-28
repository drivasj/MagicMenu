using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DigitalMenu.Models;
using DigitalMenu.Models.EntityAdministrator;
using DigitalMenu.Models.Entity.Product;
using DigitalMenu.Models.Entity;
using DigitalMenu.Models.Entity.Client;

namespace TestWeb
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Dishe> Dishes {  get; set; }
        //public DbSet<DisheCategory> Dishescategory { get; set; }
        //public DbSet<Restaurant> Restaurant { get; set; }
        //public DbSet<RestaurantDetails> Restaurantdetails { get; set; }
        //public DbSet<RestaurantEmployee> Restaurantemployee { get; set; }


        //// Entities Administrator
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeDetails> Employeedetails { get; set; }
        public DbSet<Roleuser> Roleuser { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Rolemenu> Rolemenu { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Typesystemvariable> Typesystemvariable { get; set; }
        public DbSet<Systemvariable> Systemvariable { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductTax> ProductTax { get; set; }

        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyDetails> CompanyDetails { get; set; }
        public DbSet<RoleCompany> RoleCompany { get; set; }
        public DbSet<CompanyEmployee> CompanyEmployee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientDetails> ClientDetails { get; set; }
        public DbSet<Typedocument> Typedocument { get; set; }

    }
}
