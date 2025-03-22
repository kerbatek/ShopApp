using ShopApp.Models;
using ShopApp.Repositories;

namespace ShopApp.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
    {
        return await _paymentRepository.GetAllAsync();
    }

    public async Task<Payment> GetPaymentByIdAsync(int id)
    {
        return await _paymentRepository.GetByIdAsync(id);
    }

    public async Task AddPaymentAsync(Payment payment)
    {
        await _paymentRepository.AddAsync(payment);
        await _paymentRepository.SaveChangesAsync();
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        await _paymentRepository.UpdateAsync(payment);
        await _paymentRepository.SaveChangesAsync();
    }

    public async Task DeletePaymentAsync(Payment payment)
    {
        await _paymentRepository.DeleteAsync(payment);
        await _paymentRepository.SaveChangesAsync();
    }
}