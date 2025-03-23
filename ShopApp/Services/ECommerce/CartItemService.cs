using ShopApp.Models.ECommerce;
using ShopApp.Repositories.ECommerce.Interfaces;
using ShopApp.Services.ECommerce.Interfaces;

namespace ShopApp.Services.ECommerce;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;

    public CartItemService(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }
    
    public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync()
    {
        return await _cartItemRepository.GetAllAsync();
    }

    public async Task<CartItem> GetCartItemByIdAsync(int id)
    {
        return await _cartItemRepository.GetByIdAsync(id);
    }

    public async Task AddCartItemAsync(CartItem cartItem)
    {
        await _cartItemRepository.AddAsync(cartItem);
        await _cartItemRepository.SaveChangesAsync();
    }

    public async Task UpdateCartItemAsync(CartItem cartItem)
    {
        await _cartItemRepository.UpdateAsync(cartItem);
        await _cartItemRepository.SaveChangesAsync();
    }

    public async Task DeleteCartItemAsync(CartItem cartItem)
    {
        await _cartItemRepository.DeleteAsync(cartItem);
        await _cartItemRepository.SaveChangesAsync();
    }
}