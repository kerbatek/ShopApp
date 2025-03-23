using ShopApp.Data;
using ShopApp.Models.ECommerce;
using ShopApp.Repositories.ECommerce.Interfaces;

namespace ShopApp.Repositories.ECommerce;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}