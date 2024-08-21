using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Components.BackdropLoading
{
    public class BackdropLoadingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

  
