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

    public Task<List<CartItem>> GetCartItemsWithProductsByCartIDAsync(int cartID) 
        => DbSet
            .Include(e => e.Product)
            .Where(e => e.CartID == cartID)
            .ToListAsync();

    public Task<CartItem?> GetCartItemByProductIdAsync(int productID, int cartID) 
        => DbSet.FirstOrDefaultAsync(e => e.ProductID == productID && e.CartID == cartID);
    
}