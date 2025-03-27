using System.ComponentModel.DataAnnotations;

namespace ShopApp.ViewModels;

public class RegisterViewModel
{
    
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Email is mandatory")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is mandatory")]
    [MinLength(8, ErrorMessage = "Password should be at least 8 symbols")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Date of birth is mandatory")]
    public DateTime DateOfBirth { get; set; }
}