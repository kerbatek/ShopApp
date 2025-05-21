using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;

namespace ShopApp.Repositories.Catalog;

public class InventoryRepository : Repository<Inventory>, IInventoryRepository
{
    public InventoryRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
    
    public Task<List<Inventory>> GetAllIncludingProductAsync()
        => DbSet.Include(i => i.Product)
            .ToListAsync();
    public Task<Inventory?> GetInventoryByProductIdAsync(int productId) 
        => DbSet.FirstOrDefaultAsync(i => i.ProductID == productId);
    public Task<Inventory?> GetInventoryWithProductByIdAsync(int inventoryId) 
        => DbSet.Include(i => i.Product)
            .FirstOrDefaultAsync(i => i.InventoryID == inventoryId);
}