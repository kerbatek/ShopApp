using System.ComponentModel.DataAnnotations;
using ShopApp.Models.Catalog;

namespace ShopApp.ViewModels;

public class InventoryViewModel
{
    public int InventoryId { get; set; }
    public int ProductId { get; set; }
    
    
    [Required(ErrorMessage = "Quantity is required")]
    [Range(0, 1000000, ErrorMessage = "Quantity must be between 0 and 1000000")]
    public int Quantity { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public string? ProductName { get; set; }
    public IEnumerable<Product> Products { get; set; } = [];
}