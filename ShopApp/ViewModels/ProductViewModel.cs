using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Models.Catalog;

namespace ShopApp.ViewModels;

public class ProductViewModel
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
    public string ProductName { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    public string ProductDescription { get; set; }
    
    [Required(ErrorMessage = "Price is required")]
    [Range(0, 100000, ErrorMessage = "Price must be between 0 and 100000")]
    public decimal ProductPrice { get; set; }
    
    public List<int>? CategoryIds { get; set; } 
    public IEnumerable<Category>? AvailableCategories { get; set; }
}