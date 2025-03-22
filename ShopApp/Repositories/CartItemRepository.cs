using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
    public CartItemRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}