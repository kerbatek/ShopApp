using ShopApp.Models.Logistics;

namespace ShopApp.Services.Logistics.Interfaces;

public interface IShipmentService
{
    Task<IEnumerable<Shipment>> GetAllShipmentsAsync();
    Task<Shipment> GetShipmentByIdAsync(int id);
    Task AddShipmentAsync(Shipment shipment);
    Task UpdateShipmentAsync(Shipment shipment);
    Task DeleteShipmentAsync(Shipment shipment);
}