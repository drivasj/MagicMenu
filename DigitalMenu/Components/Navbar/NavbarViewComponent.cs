using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Components.Navbar
{
    public class NavbarViewComponent : ViewComponent
    {
        public NavbarViewComponent()
        {           
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int idUser = 1;
            return View(idUser);
        }
    }
}
