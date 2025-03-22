using ShopApp.Models;
using ShopApp.Repositories;

namespace ShopApp.Services;

public class UserAddressService : IUserAddressService
{
    private readonly IUserAddressRepository _userAddressRepository;

    public UserAddressService(IUserAddressRepository userAddressRepository)
    {
        _userAddressRepository = userAddressRepository;
    }

    public async Task<IEnumerable<UserAddress>> GetAllUserAddressesAsync()
    {
        return await _userAddressRepository.GetAllAsync();
    }

    public async Task<UserAddress> GetUserAddressByIdAsync(int id)
    {
        return await _userAddressRepository.GetByIdAsync(id);
    }

    public async Task AddUserAddressAsync(UserAddress userAddress)
    {
        await _userAddressRepository.AddAsync(userAddress);
        await _userAddressRepository.SaveChangesAsync();
    }

    public async Task UpdateUserAddressAsync(UserAddress userAddress)
    {
        await _userAddressRepository.UpdateAsync(userAddress);
        await _userAddressRepository.SaveChangesAsync();
    }

    public async Task DeleteUserAddressAsync(UserAddress userAddress)
    {
        await _userAddressRepository.DeleteAsync(userAddress);
        await _userAddressRepository.SaveChangesAsync();
    }
}