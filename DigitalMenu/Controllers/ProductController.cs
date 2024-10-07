using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> ProductsList()
        {

        }
    }
}
