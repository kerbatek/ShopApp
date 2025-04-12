using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Models.Catalog;
using ShopApp.Services.Catalog.Interfaces;
using ShopApp.ViewModels;

namespace ShopApp.Controllers;
[Route("products")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductsController(IProductService productService,  ICategoryService categoryService, IProductCategoryService productCategoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var productList = await _productService.GetAllProductsWithCategoriesAsync();
        return View(productList);
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        var model = new ProductViewModel
        {
            AvailableCategories = categories,
        };
        
        return View(model);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        await _productService.CreateProductAsync(model);
        return RedirectToAction("Index");
    }

    [HttpGet("edit")]
    public async Task<IActionResult> Edit(int id)
    {
        Product product;
        try
        {
            product = await _productService.GetProductWithCategoryAsync(id);
        }
        catch (Exception)
        {
            return RedirectToAction("Index");
        }
        var categories = await _categoryService.GetAllCategoriesAsync();
    
        var model = new ProductViewModel
        {
            ProductId = product.ProductID,
            ProductName = product.ProductName,
            ProductPrice = product.Price,
            ProductDescription = product.Description,
            CategoryIds = product.ProductCategories?.Select(pc => pc.CategoryID).ToList() ?? new List<int>(),
            AvailableCategories = categories, 
            ImageUrl = product.ImageUrl,
        };

        return View(model);
    }



    [HttpPost("edit")]
    public async Task<IActionResult> Edit(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _productService.EditProductAsync(model);
        }
        catch (Exception)
        {
            // ignored
        }
        return RedirectToAction("Index");
    }

    

    [HttpPost("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            await _productService.DeleteProductByIdAsync(id);

        }
        return RedirectToAction("Index");
    }
}