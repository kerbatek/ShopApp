using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;
using ShopApp.Services.Catalog.Interfaces;
using ShopApp.ViewModels;

namespace ShopApp.Services.Catalog;

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
        var existingInventory = await _inventoryRepository.GetInventoryByProductIDAsync(inventory.ProductID);

        if (existingInventory != null)
        {
            throw new InvalidOperationException("An inventory entry for this product already exists.");
        }
        
        inventory.CreatedAt = DateTime.UtcNow;
        inventory.UpdatedAt = DateTime.UtcNow;
        
        await _inventoryRepository.AddAsync(inventory);
        await _inventoryRepository.SaveChangesAsync();
    }

    public async Task UpdateInventoryAsync(Inventory inventory)
    {
        inventory.UpdatedAt = DateTime.UtcNow;
        await _inventoryRepository.UpdateAsync(inventory);
        await _inventoryRepository.SaveChangesAsync();
    }

    public async Task UpdateInventoryAsync(int InventoryId, int Quantity)
    {
        var existingInventory = await _inventoryRepository.GetByIdAsync(InventoryId);
        if (existingInventory == null)
        {
            throw new InvalidOperationException("An inventory entry for this product does not exist.");
        }
        existingInventory.UpdatedAt = DateTime.UtcNow;
        existingInventory.Quantity = Quantity;
        
        await _inventoryRepository.UpdateAsync(existingInventory);
        await _inventoryRepository.SaveChangesAsync();
    }

    public async Task DeleteInventoryAsync(Inventory inventory)
    {
        await _inventoryRepository.DeleteAsync(inventory);
        await _inventoryRepository.SaveChangesAsync();
    }

    public async Task<IEnumerable<InventoryViewModel>> GetAllInventoriesWithProductNamesAsync()
    {
        var inventories = await _inventoryRepository.GetAllIncludingProductAsync();

        return inventories.Select(i => new InventoryViewModel
        {
            InventoryId = i.InventoryID,
            ProductId = i.ProductID,
            Quantity = i.Quantity,
            CreatedAt = i.CreatedAt,
            UpdatedAt = i.UpdatedAt,
            ProductName = i.Product.ProductName,
        });
    }

    public async Task DeleteInventoryByIdAsync(int id)
    {
        var inventory = await _inventoryRepository.GetByIdAsync(id);
        await _inventoryRepository.DeleteAsync(inventory);
        await _inventoryRepository.SaveChangesAsync();

    }

    public async Task<InventoryViewModel?> GetInventoryWithProductNameAsync(int inventoryId)
    { 
        var inventory = await _inventoryRepository.GetInventoryWithProductNameAsync(inventoryId); 
        if (inventory != null) 
        { 
            return new InventoryViewModel() 
            { 
                InventoryId = inventory.InventoryID, 
                ProductId = inventory.ProductID, 
                Quantity = inventory.Quantity, 
                CreatedAt = inventory.CreatedAt, 
                UpdatedAt = inventory.UpdatedAt, 
                ProductName = inventory.Product.ProductName, 
            }; 
        }

        return null;
    }
}