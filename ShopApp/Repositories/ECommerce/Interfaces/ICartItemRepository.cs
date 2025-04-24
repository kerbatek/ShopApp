using ShopApp.Models.ECommerce;

namespace ShopApp.Repositories.ECommerce.Interfaces;

public interface ICartItemRepository : IRepository<CartItem>
{
    public Task<List<CartItem>> GetCartItemsWithProductsByCartIDAsync(int cartID);
    public Task<CartItem?> GetCartItemByProductIdAsync(int productID, int cartID);
    
}