using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.Entity.Product;
using DigitalMenu.Models.Product;
using DigitalMenu.Services;
using DigitalMenu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IUserRepository userRepository;

        public ProductController(IProductRepository productRepository, IUserRepository userRepository)
        {
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Products()
        {
            string userName = userRepository.GetUserName();

            if (userName == null)
            {
                return BadRequest();
            }

            var listProducts = await productRepository.ListProducts();
            return View(listProducts);
        }

        [HttpPost]
        public async Task<IActionResult> ShowCreateProduct()
        {
            try
            {
                var productsCategory = await productRepository.ListProductCategory();
                var productTax = await productRepository.ListProductTax();

                var list = new ProductViewModel
                {
                    ProductsCategory = productsCategory,
                    ProductTax = productTax
                };

                return PartialView("~/Views/Product/_Partial/_CreateProductForm.cshtml", list);
            }
            catch (Exception ex) 
            {
                return Json(new { success = false, message = ex.Message });

            }

        }

        [HttpPost]
        public async Task<IActionResult> ShowDetailProduct(int idProduct)
        {
            try
            {
                var product = await productRepository._getDetailProduct(idProduct);

                return PartialView("~/Views/Product/_Partial/_DetailProductForm.cshtml", product);
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> saveProduct([FromBody] ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
                }

                var product = await productRepository.SaveProduct(model);

                return Json(new
                {
                    success = product,
                    message = product ? "Registro guardado correctamente." : "Error al intentar completar la operación."
                });
            }
            catch (Exception ex) 
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> EditProduct([FromBody] ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Json(new { success = false, message = errors });
                }

                var product = await productRepository.EditProduct(model);

                return Json(new
                {
                    success = product,
                    message = product ? "Registro guardado correctamente." : "Error al intentar completar la operación."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStateProduct([FromBody] ProductViewModel model)
        {
            try
            {
                var app = await productRepository.UpdateStateProduct(model.IdProduct);
                return Json(new
                {
                    success = app,
                    message = app ? "Registro actualizado correctamente." : "Error al intentar completar la operación"
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SearchProductCode(string filter)
        {
            ViewBag.filter = filter;
            var listFilter = await productRepository.SearchProductCode(filter);
            return View("Products", listFilter);
        }

        [HttpPost]
        public async Task<IActionResult> SearchProductStatus(string filter)
        {
            bool status;

            status = filter == "1";
            if (filter != "1" && filter != "0")
            {
                throw new ApplicationException("Filtro invalido");
            }

            ViewBag.filter = filter;
            var listFilter = await productRepository.SearchProductStatus(status);
            return View("Products", listFilter);
        }
    }
}
