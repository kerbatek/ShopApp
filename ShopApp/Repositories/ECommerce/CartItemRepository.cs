using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models.ECommerce;
using ShopApp.Repositories.ECommerce.Interfaces;

namespace ShopApp.Repositories.ECommerce;

public class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
    public CartItemRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public Task<List<CartItem>> GetCartItemsWithProductsByCartIdAsync(int cartId) 
        => DbSet
            .Include(e => e.Product)
            .Where(e => e.CartID == cartId)
            .ToListAsync();

    public Task<CartItem?> GetCartItemByProductIdAsync(int productId, int cartId) 
        => DbSet.FirstOrDefaultAsync(e => e.ProductID == productId && e.CartID == cartId);

    public Task<CartItem?> GetCartItemWithCartByIdAsync(int cartItemId)
        => DbSet.Include(ci => ci.Cart)
            .FirstOrDefaultAsync(ci => ci.CartItemID == cartItemId);
}