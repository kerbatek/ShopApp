using ShopApp.Models.ECommerce;

namespace ShopApp.Services.ECommerce.Interfaces;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> GetAllPaymentsAsync();
    Task<Payment> GetPaymentByIdAsync(int id);
    Task AddPaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(Payment payment);
}