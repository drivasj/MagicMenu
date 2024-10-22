using DigitalMenu.Models;
using DigitalMenu.Models.Administrator;
using DigitalMenu.Models.Entity.Product;
using DigitalMenu.Models.Product;
using DigitalMenu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWeb;

namespace DigitalMenu.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IUserRepository userRepository;

        public ProductRepository(ApplicationDbContext context, IUserRepository userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Listado de producto
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductViewModel>> ListProducts()
        {
            try
            {
                var products = await context.Product
                    .Include(pc => pc.productCategory)
                    .Include(pd => pd.productDetails)
                    .Select(p => new ProductViewModel
                    {
                        IdProduct = p.IdProduct,
                        NameProduct = p.productDetails.Name,
                        NameCategory = p.productCategory.Name,
                        Code = p.Code,
                        Stock = p.productDetails.Stock,
                        Description = p.productDetails.Description,
                        Price = p.productDetails.Price,
                        Active = p.Active

                    }).ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Listado categoria de producto
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductCategoryViewModel>> ListProductCategory()
        {
            try
            {
                var productCategory = await context.ProductCategory.Select(pc => new ProductCategoryViewModel
                {
                    IdProductCategory = pc.IdProductCategory,
                    Name = pc.Name,
                    Description = pc.Description
                }).ToListAsync();       

                return productCategory;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }


        /// <summary>
        /// ListProductTax
        /// </summary>
        /// <returns></returns>
        public async Task<List<TwoElement>> ListProductTax()
        {
            try
            {
                var producTax = await context.ProductTax.Select(pc => new TwoElement
                {
                    Value = pc.Code,
                    Text = pc.Description
                }).ToListAsync();

                return producTax;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }


        /// <summary>
        /// SaveProduct
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<bool> SaveProduct(ProductViewModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var userName = userRepository.GetUserName();

                    var product = new Product
                    {
                        Code = model.Code,
                        ProductCategoryId = model.ProductCategoryId,
                        StatusPromotion = false,
                        IdCompany = model.IdCompany,
                        RegisterDate =DateTime.Now,
                        RegisterUser = userName,
                        Active = true,
                        productDetails = new ProductDetails
                        {
                            Name = model.NameProduct,
                            Description = model.Description,
                            Price = model.Price,
                            Stock = model.Stock,
                            ProductTaxId = model.ProductTaxId,
                            UrlImage = model.UrlImage,
                            Active = true
                        }
                    };
                    context.Add(product);
                    await context.SaveChangesAsync();
                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new ApplicationException("Error: ", ex);
                }
            }             
        }           

        public async Task<bool> EditProduct(ProductViewModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var userName = userRepository.GetUserName();

                    var products = await context.Product
                   .Include(pc => pc.productCategory)
                   .Include(pd => pd.productDetails)
                   .FirstOrDefaultAsync(p => p.IdProduct == model.IdProduct);

                    if (products == null) { return false; }

                    products.Code = model.Code;
                    products.ProductCategoryId = model.ProductCategoryId;
                    //products.StatusPromotion = model.StatusPromotion;
                    products.IdCompany = model.IdCompany;
                    products.LastUpdate = DateTime.Now;
                    products.LastUpdateUser = userName;

                    products.productDetails.Name = model.NameProduct;
                    products.productDetails.Description = model.Description;
                    products.productDetails.Price = model.Price;
                    products.productDetails.Stock = model.Stock;
                    products.productDetails.ProductTaxId = model.ProductTaxId;
                    products.productDetails.UrlImage = model.UrlImage;
                    products.productDetails.LastUpdate = DateTime.Now;
                    products.productDetails.LastUpdateUser = userName;

                    await context.SaveChangesAsync();
                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new ApplicationException(ex.Message);
                }
            }
        }

        public async Task<ProductViewModel> _getDetailProduct(int idProduct)
        {
            try
            {
                var ListProductsCategory = await ListProductCategory();
                var ListtProductTax = await ListProductTax();

                var product = await context.Product
                                   //.Include(pc => pc.productCategory)
                                   //.Include(pd => pd.productDetails)
                                   .Where(x => x.IdProduct == idProduct).Select(p => new ProductViewModel
                                   {
                                       IdProduct = p.IdProduct,
                                       Code = p.Code,
                                       ProductCategoryId = p.ProductCategoryId,
                                       StatusPromotion = p.StatusPromotion,
                                       IdCompany = p.IdCompany,

                                       NameProduct = p.productDetails.Name,
                                       Description = p.productDetails.Description,
                                       Price = p.productDetails.Price,
                                       Stock = p.productDetails.Stock,
                                       ProductTaxId = p.productDetails.ProductTaxId,
                                       UrlImage = p.productDetails.UrlImage,
                                       Active = p.Active,
                                       ProductsCategory = ListProductsCategory,
                                       ProductTax = ListtProductTax

                                   }).FirstOrDefaultAsync();
                return product;
            }
            catch (Exception ex) 
            {
                throw new ApplicationException(ex.ToString());
            }
        }

        public async Task<bool> UpdateStateProduct(int idProduct)
        {
            try
            {
                var product = await context.Product
                    .Include(pd=>pd.productDetails)
                    .FirstOrDefaultAsync(x => x.IdProduct == idProduct);

                if (product == null) { return false; }

                bool newState = product.Active == true ? false : true;

                product.Active = newState;
                product.productDetails.Active = newState;
                await context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        }

        public async Task<List<ProductViewModel>> SearchProductCode(string filter)
        {
            try
            {
                var products = await context.Product
                    .Include(pc => pc.productCategory)
                    .Include(pd => pd.productDetails)
                    .Where(x=>x.Code == filter)
                    .Select(p => new ProductViewModel
                    {
                        IdProduct = p.IdProduct,
                        NameProduct = p.productDetails.Name,
                        NameCategory = p.productCategory.Name,
                        Code = p.Code,
                        Stock = p.productDetails.Stock,
                        Description = p.productDetails.Description,
                        Price = p.productDetails.Price,
                        Active = p.Active

                    }).ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<List<ProductViewModel>> SearchProductStatus(bool filter)
        {
            try
            {
                var products = await context.Product
                    .Include(pc => pc.productCategory)
                    .Include(pd => pd.productDetails)
                    .Where(x => x.Active == filter)
                    .Select(p => new ProductViewModel
                    {
                        IdProduct = p.IdProduct,
                        NameProduct = p.productDetails.Name,
                        NameCategory = p.productCategory.Name,
                        Code = p.Code,
                        Stock = p.productDetails.Stock,
                        Description = p.productDetails.Description,
                        Price = p.productDetails.Price,
                        Active = p.Active

                    }).ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<bool> SaveProductCategory(ProductCategoryViewModel model)
        {
            try
            {
                var userName = userRepository.GetUserName();


                var category = new ProductCategory
                {
                    Name = model.Name,
                    Code = " ",
                    Description = model.Description,
                    StatusPromotion = false,
                    IdCompany = 1,
                    RegisterDate = DateTime.Now,
                    RegisterUser = userName,
                    LastUpdate = DateTime.MinValue,
                };

                context.Add(category);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }

        public async Task<int>  CountProductCategory()
        {
            var products = await context.Product.CountAsync();
            return products;
        }
    }
}
