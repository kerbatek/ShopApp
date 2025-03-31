using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;

namespace ShopApp.Repositories.Catalog;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
    public async Task<IEnumerable<Product>> GetAllWithCategoriesAsync()
    {
        return await DbSet
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .ToListAsync();
    }

    public async Task<Product> GetByIdWithCategoryAsync(object id)
    {
        var product = await DbSet
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .FirstOrDefaultAsync(p => p.ProductID.Equals(id));

        if (product == null)
            throw new KeyNotFoundException();
        return product;
    }
}