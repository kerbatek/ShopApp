using ShopApp.Models.ECommerce;

namespace ShopApp.Repositories.ECommerce.Interfaces;

public interface ICartItemRepository : IRepository<CartItem>
{
    public Task<List<CartItem>> GetCartItemsWithProductsByCartIdAsync(int cartId);
    public Task<CartItem?> GetCartItemByProductIdAsync(int productId, int cartId);
    public Task<CartItem?> GetCartItemWithCartByIdAsync(int cartItemId);
    
}