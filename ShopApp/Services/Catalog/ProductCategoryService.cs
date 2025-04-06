using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;
using ShopApp.Services.Catalog.Interfaces;

namespace ShopApp.Services.Catalog;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync()
    {
        return await _productCategoryRepository.GetAllAsync();
    }

    public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesByProductIdAsync(int productId)
    {
        return await _productCategoryRepository.GetAllProductCategoriesByProductIdAsync(productId);
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
    public async Task UpdateProductCategoriesAsync(int productId, IEnumerable<int> newCategoryIds)
    {
        var existingCategories = await GetAllProductCategoriesByProductIdAsync(productId);
        var existingCategoryIds = existingCategories.Select(c => c.CategoryID).ToList();
        
        if (newCategoryIds != null)
        {
            foreach (var categoryId in newCategoryIds)
            {
                if (!existingCategoryIds.Contains(categoryId))
                {
                    var categoryEntry = new ProductCategory
                    {
                        AssignedAt = DateTime.UtcNow,
                        CategoryID = categoryId,
                        ProductID = productId,
                    };
                    await AddProductCategoryAsync(categoryEntry);
                }
            }
        }
        
        foreach (var category in existingCategories)
        {
            if (newCategoryIds == null || !newCategoryIds.Contains(category.CategoryID))
            {
                await DeleteProductCategoryAsync(category);
            }
        }
    }
}