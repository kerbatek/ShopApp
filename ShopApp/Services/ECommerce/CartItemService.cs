using ShopApp.Exceptions;
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

    public async Task<List<CartViewModel>> GetCartItemsByCartIdAsync(int cartId)
    {
        var itemsList = await _cartItemRepository
            .GetCartItemsWithProductsByCartIdAsync(cartId);
        
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



    public async Task AddProductToCartAsync(int productId, string userId, int quantity)
    {
        var userCart = await _cartRepository.GetCartByUserIdAsync(userId);
        if (userCart == null) throw new HttpResponseException(500, "User does not have a cart for some reason. This shouldn't happen.");
        
        var userCartId = userCart.CartID;

        try
        {
            await _productRepository.GetByIdAsync(productId); 
        }
        catch(KeyNotFoundException)
        {
            throw new HttpResponseException(400, "Product not found", true);
        }
        
        var inventory = await _inventoryRepository.GetInventoryByProductIdAsync(productId);
        if (inventory == null) throw new HttpResponseException(400, "Product doesn't have an inventory entry yet. You can't add it to cart now.", true);
        
        var availableQuantity = inventory.Quantity;

        var existingCartItem = await _cartItemRepository.GetCartItemByProductIdAsync(productId, userCartId);
        
        if (existingCartItem != null)
        {
            if (availableQuantity - existingCartItem.Quantity - quantity < 0)
            {
                throw new HttpResponseException(400, "Insufficient available quantity", true);
            }
            
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
            if (availableQuantity - quantity < 0)
            {
                throw new HttpResponseException(400, "Insufficient available quantity", true);
            }

            var newCartItem = new CartItem
            {
                CartID = userCartId,
                ProductID = productId,
                Quantity = quantity,
            };
            await AddCartItemAsync(newCartItem);
        }
    }

    public async Task DeleteCartItemByIdAsync(int cartItemId, string userId)
    {
        var cartItem = await _cartItemRepository.GetCartItemWithCartByIdAsync(cartItemId);
        if (cartItem == null) throw new HttpResponseException(400, "Cart item not found", true);
        
        if (cartItem.Cart.UserID != userId) throw new HttpResponseException(403, $"This cart doesn't belong to user {userId}.");
        
        await DeleteCartItemAsync(cartItem);
    }
}