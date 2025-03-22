using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}