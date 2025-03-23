using ShopApp.Models.Logistics;
using ShopApp.Repositories.Logistics.Interfaces;
using ShopApp.Services.Logistics.Interfaces;

namespace ShopApp.Services.Logistics;

public class TrackingService : ITrackingService
{
    private readonly ITrackingRepository _trackingRepository;

    public TrackingService(ITrackingRepository trackingRepository)
    {
        _trackingRepository = trackingRepository;
    }

    public async Task<IEnumerable<Tracking>> GetAllTrackingsAsync()
    {
        return await _trackingRepository.GetAllAsync();
    }

    public async Task<Tracking> GetTrackingByIdAsync(int id)
    {
        return await _trackingRepository.GetByIdAsync(id);
    }

    public async Task AddTrackingAsync(Tracking tracking)
    {
        await _trackingRepository.AddAsync(tracking);
        await _trackingRepository.SaveChangesAsync();
    }

    public async Task UpdateTrackingAsync(Tracking tracking)
    {
        await _trackingRepository.UpdateAsync(tracking);
        await _trackingRepository.SaveChangesAsync();
    }

    public async Task DeleteTrackingAsync(Tracking tracking)
    {
        await _trackingRepository.DeleteAsync(tracking);
        await _trackingRepository.SaveChangesAsync();
    }
}