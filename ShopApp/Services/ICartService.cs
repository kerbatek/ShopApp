using ShopApp.Models;

namespace ShopApp.Services;

public interface ICartService
{
    Task<IEnumerable<Cart>> GetAllCartsAsync();
    Task<Cart> GetCartByIdAsync(int id);
    Task AddCartAsync(Cart cart);
    Task UpdateCartAsync(Cart cart);
    Task DeleteCartAsync(Cart cart);
}