using System.ComponentModel.DataAnnotations;
namespace ShopApp.ViewModels;

public class CategoryViewModel
{
    public int CategoryId { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
    public string CategoryName { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    public string CategoryDescription { get; set; }
    
}