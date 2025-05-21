using ShopApp.Models.ECommerce;

namespace ShopApp.Repositories.ECommerce.Interfaces;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart?> GetCartByUserIdAsync(string userID);
}