using ShopApp.Models.Catalog;
using ShopApp.Repositories.Catalog.Interfaces;
using ShopApp.Services.Catalog.Interfaces;
using ShopApp.Services.Shared.Interfaces;
using ShopApp.ViewModels;

namespace ShopApp.Services.Catalog
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IImageService _imageService;

        public ProductService(
            IProductRepository productRepository,
            IProductCategoryService productCategoryService,
            IImageService imageService)
        {
            _productRepository = productRepository;
            _productCategoryService = productCategoryService;
            _imageService = imageService;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() =>
            await _productRepository.GetAllAsync();

        public async Task<IEnumerable<Product>> GetAllProductsWithCategoriesAsync() =>
            await _productRepository.GetAllWithCategoriesAsync();

        public async Task<Product> GetProductByIdAsync(int id) =>
            await _productRepository.GetByIdAsync(id);

        public async Task<Product> GetProductWithCategoryAsync(int id) =>
            await _productRepository.GetByIdWithCategoryAsync(id);

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            await _productRepository.DeleteAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            try
            {
                Product product = await _productRepository.GetByIdAsync(id);
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    await _imageService.DeleteProductImageAsync(product.ImageUrl);
                }

                await DeleteProductAsync(product);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public async Task CreateProductAsync(ProductViewModel productViewModel)
        {
            var product = new Product()
            {
                ProductName = productViewModel.ProductName,
                Price = productViewModel.ProductPrice,
                Description = productViewModel.ProductDescription,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await AddProductAsync(product);

            if (productViewModel.ProductImage != null && productViewModel.ProductImage.Length > 0)
            {
                var imageUrl = await _imageService.SaveProductImageAsync(productViewModel.ProductImage, product.ProductID);
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    product.ImageUrl = imageUrl;
                    await UpdateProductAsync(product);
                }
            }
            if (productViewModel.CategoryIds != null)
            {
                foreach (var categoryId in productViewModel.CategoryIds)
                {
                    var productCategory = new ProductCategory
                    {
                        AssignedAt = DateTime.UtcNow,
                        ProductID = product.ProductID,
                        CategoryID = categoryId,
                    };

                    await _productCategoryService.AddProductCategoryAsync(productCategory);
                }
            }
        }

        public async Task EditProductAsync(ProductViewModel productViewModel)
        {
            var product = await GetProductByIdAsync(productViewModel.ProductId);

            if (product.ProductName != productViewModel.ProductName ||
                product.Price != productViewModel.ProductPrice ||
                product.Description != productViewModel.ProductDescription)
            {
                product.ProductName = productViewModel.ProductName;
                product.Price = productViewModel.ProductPrice;
                product.Description = productViewModel.ProductDescription;
                product.UpdatedAt = DateTime.UtcNow;
            }

            if (productViewModel.ProductImage != null && productViewModel.ProductImage.Length > 0)
            {
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    await _imageService.DeleteProductImageAsync(product.ImageUrl);
                }

                var newImageUrl = await _imageService.SaveProductImageAsync(productViewModel.ProductImage, product.ProductID);
                if (!string.IsNullOrEmpty(newImageUrl))
                {
                    product.ImageUrl = newImageUrl;
                    product.UpdatedAt = DateTime.UtcNow;
                }
            }

            await UpdateProductAsync(product);

            await _productCategoryService.UpdateProductCategoriesAsync(product.ProductID, productViewModel.CategoryIds);
        }
    }
}
