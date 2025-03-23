using ShopApp.Data;
using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;

namespace ShopApp.Repositories.Catalog;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}