using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.EntityAdministrator;
using DigitalMenu.Services.Interfaces;
using TestWeb;

namespace DigitalMenu.Services
{
    public class AdministratorRepository: IAdministratorRepository
    {
        private readonly ApplicationDbContext context;

        public AdministratorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> SaveMenu(MenuViewModel model)
        {
            try
            {
                var menu = new Menu
                {
                    ApplicationId = model.ApplicationId,
                    Area = model.Area,
                    Controller = model.Controller,
                    Action = model.Action,
                    Name = model.Name = model.Name,
                    Movil = false,
                    Description = model.Description,
                    RegisterDate = DateTime.Now,
                    RegisterUser = "1",
                    Active = true
                };

                context.Add(menu);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string menssage = ex.Message;
                return false;
            }         
        }

        public async Task<bool> SaveApplication(ApplicationViewModel model)
        {
            try
            {
                var application = new Application
                {
                   Name = model.Name,
                   Description = model.Description,
                   RegisterDate = DateTime.Now,
                   RegisterUser = "1",
                   Active = true,
                   Display = model.Display,
                   Icon = model.Icon,
                };

                context.Add(application);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string menssage = ex.Message;
                return false;
            }
        }
    }
}
