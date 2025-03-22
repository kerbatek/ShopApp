using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class PaymentRepository : Repository<Payment>, IPaymentRepository
{
    public PaymentRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}