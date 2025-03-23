using ShopApp.Models.Core;

namespace ShopApp.Services.Core.Interfaces;

public interface IAddressService
{
    Task<IEnumerable<Address>> GetAllAddressesAsync();
    Task<Address> GetAddressByIdAsync(int id);
    Task AddAddressAsync(Address address);
    Task UpdateAddressAsync(Address address);
    Task DeleteAddressAsync(Address address);
}