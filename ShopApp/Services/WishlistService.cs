using ShopApp.Models;
using ShopApp.Repositories;

namespace ShopApp.Services;

public class WishlistService : IWishlistService
{
    private readonly IWishlistRepository _wishlistRepository;

    public WishlistService(IWishlistRepository wishlistRepository)
    {
        _wishlistRepository = wishlistRepository;
    }

    public async Task<IEnumerable<Wishlist>> GetAllWishlistsAsync()
    {
        return await _wishlistRepository.GetAllAsync();
    }

    public async Task<Wishlist> GetWishlistByIdAsync(int id)
    {
        return await _wishlistRepository.GetByIdAsync(id);
    }

    public async Task AddWishlistAsync(Wishlist wishlist)
    {
        await _wishlistRepository.AddAsync(wishlist);
        await _wishlistRepository.SaveChangesAsync();
    }

    public async Task UpdateWishlistAsync(Wishlist wishlist)
    {
        await _wishlistRepository.UpdateAsync(wishlist);
        await _wishlistRepository.SaveChangesAsync();
    }

    public async Task DeleteWishlistAsync(Wishlist wishlist)
    {
        await _wishlistRepository.DeleteAsync(wishlist);
        await _wishlistRepository.SaveChangesAsync();
    }
}