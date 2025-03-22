using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}