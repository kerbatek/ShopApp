using Microsoft.AspNetCore.Mvc;
using ShopApp.Models.Catalog;
using ShopApp.Services.Catalog.Interfaces;
using ShopApp.ViewModels;

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

    [HttpPost("create")]
    public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
    {
        if (ModelState.IsValid)
        {
           await _categoryService.CreateCategoryAsync(categoryViewModel);
        }
        return RedirectToAction("Index");
    }
    
    [HttpPost("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.DeleteCategoryByIdAsync(id);

        }
        return RedirectToAction("Index");
    }

    [HttpGet("edit")]
    public async Task<IActionResult> Edit(int id)
    {
        Category category;
        
        try
        {
            category = await _categoryService.GetCategoryByIdAsync(id);
        }
        
        catch (Exception)
        {
            return RedirectToAction("Index");
        }
        
        var model = new CategoryViewModel()
        {
            CategoryId = category.CategoryID,
            CategoryName = category.CategoryName,
            CategoryDescription = category.CategoryDescription,
        };
        
        return View(model);
    }

    [HttpPost("edit")]
    public async Task<IActionResult> Edit(CategoryViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        try
        {
            await _categoryService.EditCategoryAsync(model);
        }
        catch (Exception)
        {
            //ignored
        }

        return RedirectToAction("Index");
    }
}   
