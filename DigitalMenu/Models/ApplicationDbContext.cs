﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DigitalMenu.Models;
using DigitalMenu.Models.EntityAdministrator;

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

    }
}
