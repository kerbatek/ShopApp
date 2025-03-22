using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}