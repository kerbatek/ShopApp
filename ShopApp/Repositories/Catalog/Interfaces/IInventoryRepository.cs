using ShopApp.Models.Catalog;

namespace ShopApp.Repositories.Catalog.Interfaces;

public interface IInventoryRepository : IRepository<Inventory>
{
    Task<List<Inventory>> GetAllIncludingProductAsync();
    Task<Inventory?> GetInventoryByProductIdAsync(int productId);
    Task<Inventory?> GetInventoryWithProductByIdAsync(int inventoryId);
}