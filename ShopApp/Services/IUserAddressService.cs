using ShopApp.Models;

namespace ShopApp.Services;

public interface IUserAddressService
{
    Task<IEnumerable<UserAddress>> GetAllUserAddressesAsync();
    Task<UserAddress> GetUserAddressByIdAsync(int id);
    Task AddUserAddressAsync(UserAddress userAddress);
    Task UpdateUserAddressAsync(UserAddress userAddress);
    Task DeleteUserAddressAsync(UserAddress userAddress);
}