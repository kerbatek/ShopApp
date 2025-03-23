using ShopApp.Data;
using ShopApp.Models.ECommerce;
using ShopApp.Repositories.ECommerce.Interfaces;

namespace ShopApp.Repositories.ECommerce;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}