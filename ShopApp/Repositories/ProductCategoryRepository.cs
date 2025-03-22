using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}