using ShopApp.Models;
using ShopApp.Repositories;

namespace ShopApp.Services;

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
}