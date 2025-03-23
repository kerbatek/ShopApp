using ShopApp.Data;
using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;

namespace ShopApp.Repositories.Catalog;

public class InventoryRepository : Repository<Inventory>, IInventoryRepository
{
    public InventoryRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}