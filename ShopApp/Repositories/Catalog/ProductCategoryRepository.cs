using ShopApp.Data;
using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;

namespace ShopApp.Repositories.Catalog;

public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}