using ShopApp.Models.ECommerce;
using ShopApp.Repositories.ECommerce.Interfaces;
using ShopApp.Services.ECommerce.Interfaces;
using ShopApp.ViewModels;

namespace ShopApp.Services.ECommerce;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;

    public CartItemService(ICartItemRepository cartItemRepository,  ICartRepository cartRepository)
    {
        _cartItemRepository = cartItemRepository;
        _cartRepository = cartRepository;
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
        var existingCartItem = await _cartItemRepository.GetCartItemByProductIdAsync(productID, userCartID);
        
        if (existingCartItem != null)
        {
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
            var newCartItem = new CartItem
            {
                CartID = userCartID,
                ProductID = productID,
                Quantity = quantity,
            };
            await AddCartItemAsync(newCartItem);
        }
    }

    public async Task DeleteCartItemByIDAsync(int cartItemID)
    {
        var cartItem = await _cartItemRepository.GetByIdAsync(cartItemID);
        await DeleteCartItemAsync(cartItem);
    }
}