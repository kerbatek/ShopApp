namespace ShopApp.Services.Shared.Interfaces
{
    public interface IImageService
    {
        Task<string> SaveProductImageAsync(IFormFile file, int productId);
        Task DeleteProductImageAsync(string imageUrl);
    }  
}
