using Microsoft.AspNetCore.Identity;

namespace ShopApp.Models;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; }
}