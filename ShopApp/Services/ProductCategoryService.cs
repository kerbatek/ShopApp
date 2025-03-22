using ShopApp.Models;
using ShopApp.Repositories;

namespace ShopApp.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<IEnumerable<ProductCategory>> GetAllProductCategorysAsync()
    {
        return await _productCategoryRepository.GetAllAsync();
    }

    public async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
    {
        return await _productCategoryRepository.GetByIdAsync(id);
    }

    public async Task AddProductCategoryAsync(ProductCategory productCategory)
    {
        await _productCategoryRepository.AddAsync(productCategory);
        await _productCategoryRepository.SaveChangesAsync();
    }

    public async Task UpdateProductCategoryAsync(ProductCategory productCategory)
    {
        await _productCategoryRepository.UpdateAsync(productCategory);
        await _productCategoryRepository.SaveChangesAsync();
    }

    public async Task DeleteProductCategoryAsync(ProductCategory productCategory)
    {
        await _productCategoryRepository.DeleteAsync(productCategory);
        await _productCategoryRepository.SaveChangesAsync();
    }
}