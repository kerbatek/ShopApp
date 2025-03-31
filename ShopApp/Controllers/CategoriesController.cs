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
            var category = new Category()
            {
                CategoryName = categoryViewModel.CategoryName,
                CategoryDescription = categoryViewModel.CategoryDescription,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            await _categoryService.AddCategoryAsync(category);
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
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        var category = await _categoryService.GetCategoryByIdAsync(id);
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
        var category = await _categoryService.GetCategoryByIdAsync(model.CategoryId);
        if (model.CategoryId != category.CategoryID || model.CategoryName != category.CategoryName || model.CategoryDescription != category.CategoryDescription)
        {
            category.CategoryName = model.CategoryName;
            category.CategoryDescription = model.CategoryDescription;
            category.UpdatedAt = DateTime.UtcNow;
            await _categoryService.UpdateCategoryAsync(category);
        }
        return RedirectToAction("Index");
    }
    
}   
