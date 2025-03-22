using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class InventoryRepository : Repository<Inventory>, IInventoryRepository
{
    public InventoryRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}