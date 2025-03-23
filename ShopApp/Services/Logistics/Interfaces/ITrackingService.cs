using ShopApp.Models.Logistics;

namespace ShopApp.Services.Logistics.Interfaces;

public interface ITrackingService
{
    Task<IEnumerable<Tracking>> GetAllTrackingsAsync();
    Task<Tracking> GetTrackingByIdAsync(int id);
    Task AddTrackingAsync(Tracking tracking);
    Task UpdateTrackingAsync(Tracking tracking);
    Task DeleteTrackingAsync(Tracking tracking);
}