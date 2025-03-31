using ShopApp.Models.Catalog;

namespace ShopApp.Repositories.Catalog.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    public Task<IEnumerable<Product>> GetAllWithCategoriesAsync();
    public Task<Product> GetByIdWithCategoryAsync(object id);

}