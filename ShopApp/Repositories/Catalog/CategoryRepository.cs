using ShopApp.Data;
using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;

namespace ShopApp.Repositories.Catalog;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}