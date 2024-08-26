using DigitalMenu.Services.Interfaces;
using DigitalMenu.Services;
using Microsoft.EntityFrameworkCore;
using TestWeb;
using DigitalMenu.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

var politicaUsuarioAutenticados = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); // solo usuarios Autenticados

//Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
   options.Filters.Add(new AuthorizeFilter(politicaUsuarioAutenticados)); //Configuración aceptar solo usuarios Autenticados

}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // JsonSerializerOptions
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


//Mysql
builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    options.UseMySQL(connectionString);
});

//Identity 
builder.Services.AddAuthentication(); //Activar los servicios de Authentication

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // El usuario no requiere confirmar la cuenta para logearse 
}).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
{
    options.LoginPath = "/Administrator/login"; //URL login
    options.AccessDeniedPath = "/usuarios/login"; // URL Acceso denegado
});


builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAdministratorRepository, AdministratorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
