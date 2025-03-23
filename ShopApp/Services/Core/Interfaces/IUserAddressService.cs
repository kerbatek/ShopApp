using ShopApp.Models.Core;

namespace ShopApp.Services.Core.Interfaces;

public interface IUserAddressService
{
    Task<IEnumerable<UserAddress>> GetAllUserAddressesAsync();
    Task<UserAddress> GetUserAddressByIdAsync(int id);
    Task AddUserAddressAsync(UserAddress userAddress);
    Task UpdateUserAddressAsync(UserAddress userAddress);
    Task DeleteUserAddressAsync(UserAddress userAddress);
}