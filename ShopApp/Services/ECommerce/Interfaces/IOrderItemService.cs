using ShopApp.Models.ECommerce;

namespace ShopApp.Services.ECommerce.Interfaces;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
    Task<OrderItem> GetOrderItemByIdAsync(int id);
    Task AddOrderItemAsync(OrderItem orderItem);
    Task UpdateOrderItemAsync(OrderItem orderItem);
    Task DeleteOrderItemAsync(OrderItem orderItem);
}