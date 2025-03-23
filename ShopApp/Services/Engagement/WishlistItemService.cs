using ShopApp.Models.Engagement;
using ShopApp.Repositories.Engagement.Interfaces;
using ShopApp.Services.Engagement.Interfaces;

namespace ShopApp.Services.Engagement;

public class WishlistItemService : IWishlistItemService
{
    private readonly IWishlistItemRepository _wishlistItemRepository;

    public WishlistItemService(IWishlistItemRepository wishlistItemRepository)
    {
        _wishlistItemRepository = wishlistItemRepository;
    }

    public async Task<IEnumerable<WishlistItem>> GetAllWishlistItemsAsync()
    {
        return await _wishlistItemRepository.GetAllAsync();
    }

    public async Task<WishlistItem> GetWishlistItemByIdAsync(int id)
    {
        return await _wishlistItemRepository.GetByIdAsync(id);
    }

    public async Task AddWishlistItemAsync(WishlistItem wishlistItem)
    {
        await _wishlistItemRepository.AddAsync(wishlistItem);
        await _wishlistItemRepository.SaveChangesAsync();
    }

    public async Task UpdateWishlistItemAsync(WishlistItem wishlistItem)
    {
        await _wishlistItemRepository.UpdateAsync(wishlistItem);
        await _wishlistItemRepository.SaveChangesAsync();
    }

    public async Task DeleteWishlistItemAsync(WishlistItem wishlistItem)
    {
        await _wishlistItemRepository.DeleteAsync(wishlistItem);
        await _wishlistItemRepository.SaveChangesAsync();
    }
}