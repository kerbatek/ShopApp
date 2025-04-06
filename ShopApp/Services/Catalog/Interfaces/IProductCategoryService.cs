using ShopApp.Models.Catalog;

namespace ShopApp.Services.Catalog.Interfaces;

public interface IProductCategoryService
{
    Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync();
    Task<IEnumerable<ProductCategory>> GetAllProductCategoriesByProductIdAsync(int productId);
    Task<ProductCategory> GetProductCategoryByIdAsync(int id);
    Task AddProductCategoryAsync(ProductCategory productCategory);
    Task UpdateProductCategoryAsync(ProductCategory productCategory);
    Task DeleteProductCategoryAsync(ProductCategory productCategory);
    Task UpdateProductCategoriesAsync(int productId, IEnumerable<int> newCategoryIds);
}