using ShopApp.Models.Logistics;
using ShopApp.Repositories.Logistics.Interfaces;
using ShopApp.Services.Logistics.Interfaces;

namespace ShopApp.Services.Logistics;

public class ShipmentService : IShipmentService
{
    private readonly IShipmentRepository _shipmentRepository;

    public ShipmentService(IShipmentRepository shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<IEnumerable<Shipment>> GetAllShipmentsAsync()
    {
        return await _shipmentRepository.GetAllAsync();
    }

    public async Task<Shipment> GetShipmentByIdAsync(int id)
    {
        return await _shipmentRepository.GetByIdAsync(id);
    }

    public async Task AddShipmentAsync(Shipment shipment)
    {
        await _shipmentRepository.AddAsync(shipment);
        await _shipmentRepository.SaveChangesAsync();
    }

    public async Task UpdateShipmentAsync(Shipment shipment)
    {
        await _shipmentRepository.UpdateAsync(shipment);
        await _shipmentRepository.SaveChangesAsync();
    }

    public async Task DeleteShipmentAsync(Shipment shipment)
    {
        await _shipmentRepository.DeleteAsync(shipment);
        await _shipmentRepository.SaveChangesAsync();
    }
}