using ShopApp.Models.ECommerce;

namespace ShopApp.Services.ECommerce.Interfaces;

public interface ICartService
{
    Task<IEnumerable<Cart>> GetAllCartsAsync();
    Task<Cart> GetCartByIdAsync(int id);
    Task AddCartAsync(Cart cart);
    Task UpdateCartAsync(Cart cart);
    Task DeleteCartAsync(Cart cart);
    Task<Cart> GetUserCartAsync(string userID);
}