using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}