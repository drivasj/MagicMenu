using DigitalMenu.Models;
using DigitalMenu.Models.Product;

namespace DigitalMenu.Services.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductCategoryViewModel>> ListProductCategory();
        Task<List<ProductViewModel>> ListProducts();
        Task<List<TwoElement>> ListProductTax();
        Task<bool> SaveProduct(ProductViewModel model);
        Task<bool> EditProduct(ProductViewModel model);
        Task<ProductViewModel> _getDetailProduct(int idProduct);
        Task<bool> UpdateStateProduct(int idProduct);
        Task<List<ProductViewModel>> SearchProductCode(string filter);
        Task<List<ProductViewModel>> SearchProductStatus(bool filter);
        Task<bool> SaveProductCategory(ProductCategoryViewModel model);
        Task<int> CountProductCategory();
        Task<List<ProductCategoryViewModel>> ListProductCategory(int numrow, int page);
    }
}
