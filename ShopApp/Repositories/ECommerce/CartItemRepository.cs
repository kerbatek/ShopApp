using ShopApp.Data;
using ShopApp.Models.ECommerce;
using ShopApp.Repositories.ECommerce.Interfaces;

namespace ShopApp.Repositories.ECommerce;

public class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
    public CartItemRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}