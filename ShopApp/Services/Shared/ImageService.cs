using ShopApp.Services.Shared.Interfaces;

namespace ShopApp.Services.Shared
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveProductImageAsync(IFormFile file, int productId)
        {
            if (file == null || file.Length == 0)
                return null;

            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{productId}{fileExtension}";
            var imageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");

            Directory.CreateDirectory(imageFolder);
            var imagePath = Path.Combine(imageFolder, fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/images/products/{fileName}";
        }

        public Task DeleteProductImageAsync(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return Task.CompletedTask;
        
            var relativePath = imageUrl.TrimStart('/');
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, relativePath);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return Task.CompletedTask;
        }
    }
}

