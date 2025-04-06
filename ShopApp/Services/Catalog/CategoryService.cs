using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;
using ShopApp.Services.Catalog.Interfaces;
using ShopApp.ViewModels;

namespace ShopApp.Services.Catalog;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        await _categoryRepository.UpdateAsync(category);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        await _categoryRepository.DeleteAsync(category);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task DeleteCategoryByIdAsync(int id)
    {
        try
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }
        catch (Exception e)
        {
            // ignored
        }
    }

    public async Task CreateCategoryAsync(CategoryViewModel categoryViewModel)
    {
        var category = new Category()
        {
            CategoryName = categoryViewModel.CategoryName,
            CategoryDescription = categoryViewModel.CategoryDescription,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,

        };
        await AddCategoryAsync(category);
    }

    public async Task EditCategoryAsync(CategoryViewModel categoryViewModel)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryViewModel.CategoryId);
        if (categoryViewModel.CategoryName != category.CategoryName 
            || categoryViewModel.CategoryDescription != category.CategoryDescription)
        {
            category.CategoryName = categoryViewModel.CategoryName;
            category.CategoryDescription = categoryViewModel.CategoryDescription;
            category.UpdatedAt = DateTime.UtcNow;
            await UpdateCategoryAsync(category);
        }
    }
}