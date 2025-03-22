using ShopApp.Models;

namespace ShopApp.Services;

public interface ITrackingService
{
    Task<IEnumerable<Tracking>> GetAllTrackingsAsync();
    Task<Tracking> GetTrackingByIdAsync(int id);
    Task AddTrackingAsync(Tracking tracking);
    Task UpdateTrackingAsync(Tracking tracking);
    Task DeleteTrackingAsync(Tracking tracking);
}