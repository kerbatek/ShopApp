using ShopApp.Models.ECommerce;
using ShopApp.Repositories.ECommerce.Interfaces;
using ShopApp.Services.ECommerce.Interfaces;

namespace ShopApp.Services.ECommerce;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<IEnumerable<Cart>> GetAllCartsAsync()
    {
        return await _cartRepository.GetAllAsync();
    }

    public async Task<Cart> GetCartByIdAsync(int id)
    {
        return await _cartRepository.GetByIdAsync(id);
    }

    public async Task AddCartAsync(Cart cart)
    {
        await _cartRepository.AddAsync(cart);
        await _cartRepository.SaveChangesAsync();
    }

    public async Task UpdateCartAsync(Cart cart)
    {
        await _cartRepository.UpdateAsync(cart);
        await _cartRepository.SaveChangesAsync();
    }

    public async Task DeleteCartAsync(Cart cart)
    {
        await _cartRepository.DeleteAsync(cart);
        await _cartRepository.SaveChangesAsync();
    }

    public async Task<Cart> GetUserCartAsync(string userID)
    {
        var cart = await _cartRepository.GetCartByUserIdAsync(userID);
        
        if (cart != null) return cart;
        
        Cart newCart = new Cart
        {
            UserID = userID,
            Status = "Active",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        await AddCartAsync(newCart);
        
        return await _cartRepository.GetCartByUserIdAsync(userID) ?? newCart;
    }
}