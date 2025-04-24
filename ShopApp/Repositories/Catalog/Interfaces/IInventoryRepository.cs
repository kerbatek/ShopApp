using ShopApp.Models.Catalog;
using ShopApp.ViewModels;

namespace ShopApp.Repositories.Catalog.Interfaces;

public interface IInventoryRepository : IRepository<Inventory>
{
    Task<List<Inventory>> GetAllIncludingProductAsync();
    Task<Inventory?> GetInventoryByProductIDAsync(int productID);
    Task<Inventory?> GetInventoryWithProductNameAsync(int inventoryId);
}