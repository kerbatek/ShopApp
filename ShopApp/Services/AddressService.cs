using ShopApp.Models;
using ShopApp.Repositories;

namespace ShopApp.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<IEnumerable<Address>> GetAllAddressesAsync()
    {
        return await _addressRepository.GetAllAsync();
    }

    public async Task<Address> GetAddressByIdAsync(int id)
    {
        return await _addressRepository.GetByIdAsync(id);
    }

    public async Task AddAddressAsync(Address address)
    {
        await _addressRepository.AddAsync(address);
        await _addressRepository.SaveChangesAsync();
    }

    public async Task UpdateAddressAsync(Address address)
    {
        await _addressRepository.UpdateAsync(address);
        await _addressRepository.SaveChangesAsync();
    }

    public async Task DeleteAddressAsync(Address address)
    {
        await _addressRepository.DeleteAsync(address);
        await _addressRepository.SaveChangesAsync();
    }
    
}