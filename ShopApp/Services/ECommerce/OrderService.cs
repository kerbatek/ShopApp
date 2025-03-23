using ShopApp.Models.ECommerce;
using ShopApp.Repositories.ECommerce.Interfaces;
using ShopApp.Services.ECommerce.Interfaces;

namespace ShopApp.Services.ECommerce;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task AddOrderAsync(Order order)
    {
        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        await _orderRepository.UpdateAsync(order);
        await _orderRepository.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(Order order)
    {
        await _orderRepository.DeleteAsync(order);
        await _orderRepository.SaveChangesAsync();
    }
}