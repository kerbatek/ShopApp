using ShopApp.Models;

namespace ShopApp.Services;

public interface IProductCategoryService
{
    Task<IEnumerable<ProductCategory>> GetAllProductCategorysAsync();
    Task<ProductCategory> GetProductCategoryByIdAsync(int id);
    Task AddProductCategoryAsync(ProductCategory productCategory);
    Task UpdateProductCategoryAsync(ProductCategory productCategory);
    Task DeleteProductCategoryAsync(ProductCategory productCategory);
}