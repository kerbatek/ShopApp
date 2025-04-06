using ShopApp.Models.Catalog;
using ShopApp.ViewModels;

namespace ShopApp.Services.Catalog.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Category category);
    Task DeleteCategoryByIdAsync(int id);
    Task CreateCategoryAsync(CategoryViewModel categoryViewModel);
    Task EditCategoryAsync(CategoryViewModel categoryViewModel);
}