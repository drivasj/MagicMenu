using DigitalMenu.Models.CategoryDishe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWeb;

namespace DigitalMenu.Controllers
{

    public class CategoryDisheController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryDisheController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var model = await context.Dishescategory.Select(c => new CategoryDashViewModel
        //    {
        //        IdDishesCategory = c.IdDishesCategory,
        //        Name = c.Name,
        //        Description = c.Description,
        //    }).ToListAsync();

        //    return View(model);
        //}
    }
}
