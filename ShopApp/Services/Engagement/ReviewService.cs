using ShopApp.Models.Engagement;
using ShopApp.Repositories.Engagement.Interfaces;
using ShopApp.Services.Engagement.Interfaces;

namespace ShopApp.Services.Engagement;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<Review>> GetAllReviewsAsync()
    {
        return await _reviewRepository.GetAllAsync();
    }

    public async Task<Review> GetReviewByIdAsync(int id)
    {
        return await _reviewRepository.GetByIdAsync(id);
    }

    public async Task AddReviewAsync(Review review)
    {
        await _reviewRepository.AddAsync(review);
        await _reviewRepository.SaveChangesAsync();
    }

    public async Task UpdateReviewAsync(Review review)
    {
        await _reviewRepository.UpdateAsync(review);
        await _reviewRepository.SaveChangesAsync();
    }

    public async Task DeleteReviewAsync(Review review)
    {
        await _reviewRepository.DeleteAsync(review);
        await _reviewRepository.SaveChangesAsync();
    }
}