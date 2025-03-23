using ShopApp.Models.Engagement;

namespace ShopApp.Services.Engagement.Interfaces;

public interface IReviewService
{
    Task<IEnumerable<Review>> GetAllReviewsAsync();
    Task<Review> GetReviewByIdAsync(int id);
    Task AddReviewAsync(Review review);
    Task UpdateReviewAsync(Review review);
    Task DeleteReviewAsync(Review review);
}