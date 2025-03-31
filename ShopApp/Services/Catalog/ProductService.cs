using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;
using ShopApp.Services.Catalog.Interfaces;

namespace ShopApp.Services.Catalog;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProductsWithCategoriesAsync()
    {
        return await _productRepository.GetAllWithCategoriesAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<Product> GetProductWithCategoryAsync(int id)
    {
        return await _productRepository.GetByIdWithCategoryAsync(id);
    }

    public async Task AddProductAsync(Product product)
    {
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        await _productRepository.UpdateAsync(product);
        await _productRepository.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Product product)
    {
        await _productRepository.DeleteAsync(product);
        await _productRepository.SaveChangesAsync();
    }
    
    public async Task DeleteProductByIdAsync(int id)
    {
        try
        {
            Product product = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(product);
            await _productRepository.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return;
        }
        
    }
    
}