using ShopApp.Models.Catalog;

namespace ShopApp.Repositories.Catalog.Interfaces;

public interface IProductCategoryRepository : IRepository<ProductCategory>
{
    public Task<IEnumerable<ProductCategory>> GetAllProductCategoriesByProductIdAsync(int productId);
}