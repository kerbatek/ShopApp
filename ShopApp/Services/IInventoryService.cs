using ShopApp.Models;

namespace ShopApp.Services;

public interface IInventoryService
{
    Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
    Task<Inventory> GetInventoryByIdAsync(int id);
    Task AddInventoryAsync(Inventory inventory);
    Task UpdateInventoryAsync(Inventory inventory);
    Task DeleteInventoryAsync(Inventory inventory);
}