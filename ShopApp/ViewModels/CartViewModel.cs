namespace ShopApp.ViewModels;

public class CartViewModel
{
    public int CartID { get; set; }
    
    public int CartItemID { get; set; }
    public int Quantity { get; set; }
    
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string? ProductImageUrl { get; set; }
}