using ShopApp.Models.Catalog;
using ShopApp.ViewModels;

namespace ShopApp.Services.Catalog.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetAllProductsWithCategoriesAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> GetProductWithCategoryAsync(int id);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(Product product);
    Task DeleteProductByIdAsync(int id);
    Task CreateProductAsync(ProductViewModel productViewModel);
    Task EditProductAsync(ProductViewModel productViewModel);
    
}