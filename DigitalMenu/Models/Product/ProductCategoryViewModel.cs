namespace DigitalMenu.Models.Product
{
    public class ProductCategoryViewModel
    {
        public int IdProductCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductCategoryViewModel> ProductCategories { get; set; }

        /// <summary>
        /// paginado
        /// </summary>
        public PagedList Paged { get; set; }
    }
}
