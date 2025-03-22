using ShopApp.Models;
using ShopApp.Repositories;

namespace ShopApp.Services;

public class InventoryService :  IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;

    public InventoryService(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
    {
        return await _inventoryRepository.GetAllAsync();
    }

    public async Task<Inventory> GetInventoryByIdAsync(int id)
    {
        return await _inventoryRepository.GetByIdAsync(id);
    }

    public async Task AddInventoryAsync(Inventory inventory)
    {
        await _inventoryRepository.AddAsync(inventory);
        await _inventoryRepository.SaveChangesAsync();
    }

    public async Task UpdateInventoryAsync(Inventory inventory)
    {
        await _inventoryRepository.UpdateAsync(inventory);
        await _inventoryRepository.SaveChangesAsync();
    }

    public async Task DeleteInventoryAsync(Inventory inventory)
    {
        await _inventoryRepository.DeleteAsync(inventory);
        await _inventoryRepository.SaveChangesAsync();
    }
}