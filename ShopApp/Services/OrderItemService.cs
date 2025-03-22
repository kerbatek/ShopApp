using ShopApp.Models;
using ShopApp.Repositories;

namespace ShopApp.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
    {
        return await _orderItemRepository.GetAllAsync();
    }

    public async Task<OrderItem> GetOrderItemByIdAsync(int id)
    {
        return await _orderItemRepository.GetByIdAsync(id);
    }

    public async Task AddOrderItemAsync(OrderItem orderItem)
    {
        await _orderItemRepository.AddAsync(orderItem);
        await _orderItemRepository.SaveChangesAsync();
    }

    public async Task UpdateOrderItemAsync(OrderItem orderItem)
    {
        await _orderItemRepository.UpdateAsync(orderItem);
        await _orderItemRepository.SaveChangesAsync();
    }

    public async Task DeleteOrderItemAsync(OrderItem orderItem)
    {
        await _orderItemRepository.DeleteAsync(orderItem);
        await _orderItemRepository.SaveChangesAsync();
    }
}