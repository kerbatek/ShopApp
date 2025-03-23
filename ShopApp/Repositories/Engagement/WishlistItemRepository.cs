using ShopApp.Data;
using ShopApp.Models.Engagement;
using ShopApp.Repositories.Engagement.Interfaces;

namespace ShopApp.Repositories.Engagement;

public class WishlistItemRepository : Repository<WishlistItem>, IWishlistItemRepository
{
    public WishlistItemRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}