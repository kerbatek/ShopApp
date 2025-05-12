using ShopApp.Models.ECommerce;
using ShopApp.Repositories.Catalog.Interfaces;
using ShopApp.Repositories.ECommerce.Interfaces;
using ShopApp.Services.ECommerce.Interfaces;
using ShopApp.ViewModels;

namespace ShopApp.Services.ECommerce;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IInventoryRepository _inventoryRepository;

    public CartItemService(ICartItemRepository cartItemRepository,  ICartRepository cartRepository,  
        IProductRepository productRepository, IInventoryRepository inventoryRepository)
    {
        _cartItemRepository = cartItemRepository;
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _inventoryRepository = inventoryRepository;
    }
    
    public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync()
    {
        return await _cartItemRepository.GetAllAsync();
    }

    public async Task<CartItem> GetCartItemByIdAsync(int id)
    {
        return await _cartItemRepository.GetByIdAsync(id);
    }

    public async Task AddCartItemAsync(CartItem cartItem)
    {
        await _cartItemRepository.AddAsync(cartItem);
        await _cartItemRepository.SaveChangesAsync();
    }

    public async Task UpdateCartItemAsync(CartItem cartItem)
    {
        await _cartItemRepository.UpdateAsync(cartItem);
        await _cartItemRepository.SaveChangesAsync();
    }

    public async Task DeleteCartItemAsync(CartItem cartItem)
    {
        await _cartItemRepository.DeleteAsync(cartItem);
        await _cartItemRepository.SaveChangesAsync();
    }

    public async Task<List<CartViewModel>> GetCartItemsByCartIDAsync(int cartID)
    {
        var itemsList = await _cartItemRepository
            .GetCartItemsWithProductsByCartIDAsync(cartID);
        
        var modelList = itemsList.Select(item => new CartViewModel
        {
            CartID = item.CartID,
            CartItemID = item.CartItemID,
            Quantity = item.Quantity,
            ProductID = item.ProductID,
            ProductName = item.Product.ProductName,
            ProductPrice = item.Product.Price,
            ProductImageUrl = item.Product.ImageUrl,
        })
            .OrderBy(item => item.ProductName)
            .ToList();
        
        return modelList;
    }



    public async Task AddProductToCartAsync(int productID, string userID, int quantity)
    {
        var userCart = await _cartRepository.GetCartByUserIdAsync(userID);
        var userCartID = userCart.CartID;

        await _productRepository.GetByIdAsync(productID);  //throws KeyNotFoundException() if not found
        
        var inventory = await _inventoryRepository.GetInventoryByProductIDAsync(productID);
        var availableQuantity = inventory.Quantity;

        var existingCartItem = await _cartItemRepository.GetCartItemByProductIdAsync(productID, userCartID);
        
        if (existingCartItem != null)
        {
            if (availableQuantity - existingCartItem.Quantity - quantity < 0) throw new InvalidOperationException("Insufficient available quantity");
            
            existingCartItem.Quantity += quantity;
            if (existingCartItem.Quantity <= 0)
            {
                await DeleteCartItemAsync(existingCartItem);
            }
            else
            {
                await UpdateCartItemAsync(existingCartItem);
            }
        }
        else
        {
            if (availableQuantity - quantity < 0) throw new InvalidOperationException("Insufficient available quantity");

            var newCartItem = new CartItem
            {
                CartID = userCartID,
                ProductID = productID,
                Quantity = quantity,
            };
            await AddCartItemAsync(newCartItem);
        }
    }

    public async Task DeleteCartItemByIDAsync(int cartItemID, string userID)
    {
        var cartItem = await _cartItemRepository.GetCartItemWithCartByIdAsync(cartItemID);
        if (cartItem == null) throw new KeyNotFoundException($"CartItem with ID {cartItemID} not found");
        
        if (cartItem.Cart.UserID != userID) throw new UnauthorizedAccessException($"User with ID {userID} may not delete this item");
        
        await DeleteCartItemAsync(cartItem);
    }
}