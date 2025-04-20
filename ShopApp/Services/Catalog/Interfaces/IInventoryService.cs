using ShopApp.Models.Catalog;
using ShopApp.ViewModels;

namespace ShopApp.Services.Catalog.Interfaces;

public interface IInventoryService
{
    Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
    Task<Inventory> GetInventoryByIdAsync(int id);
    Task AddInventoryAsync(Inventory inventory);
    Task UpdateInventoryAsync(Inventory inventory);
    Task UpdateInventoryAsync(int InventoryId, int Quantity);
    Task DeleteInventoryAsync(Inventory inventory);
    
    Task<IEnumerable<InventoryViewModel>> GetAllInventoriesWithProductNamesAsync();
    Task<InventoryViewModel?> GetInventoryWithProductNameAsync(int inventoryId);
    Task DeleteInventoryByIdAsync(int id);
}