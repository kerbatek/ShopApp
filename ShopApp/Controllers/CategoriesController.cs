using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.Catalog.Interfaces;

namespace ShopApp.Controllers;
[Route("/categories")]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var categoryList = await _categoryService.GetAllCategoriesAsync();
        return View(categoryList);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }
}   
