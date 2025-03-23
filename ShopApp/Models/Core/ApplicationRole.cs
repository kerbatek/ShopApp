using Microsoft.AspNetCore.Identity;

namespace ShopApp.Models.Core;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; }
}