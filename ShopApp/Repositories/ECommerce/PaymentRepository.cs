using ShopApp.Data;
using ShopApp.Models.ECommerce;
using ShopApp.Repositories.ECommerce.Interfaces;

namespace ShopApp.Repositories.ECommerce;

public class PaymentRepository : Repository<Payment>, IPaymentRepository
{
    public PaymentRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}