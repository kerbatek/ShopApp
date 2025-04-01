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
    private readonly IProductCategoryService _productCategoryService;

    public ProductsController(IProductService productService,  ICategoryService categoryService, IProductCategoryService productCategoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _productCategoryService = productCategoryService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var productList = await _productService.GetAllProductsWithCategoriesAsync();
        return View(productList);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var product = new Product()
        {
            ProductName = model.ProductName,
            Price = model.ProductPrice,
            Description = model.ProductDescription,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        await _productService.AddProductAsync(product);
        return RedirectToAction("Index");

    }

    [HttpGet("edit")]
    public async Task<IActionResult> Edit(int id)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        
        var product = await _productService.GetProductWithCategoryAsync(id);
        var categories = await _categoryService.GetAllCategoriesAsync();
    
        var model = new ProductViewModel
        {
            ProductId = product.ProductID,
            ProductName = product.ProductName,
            ProductPrice = product.Price,
            ProductDescription = product.Description,
            CategoryIds = product.ProductCategories?.Select(pc => pc.CategoryID).ToList() ?? new List<int>(),
            AvailableCategories = categories 
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

        var product = await _productService.GetProductByIdAsync(model.ProductId);
        
        if (product.ProductName != model.ProductName ||
            product.Price != model.ProductPrice ||
            product.Description != model.ProductDescription)
        {
            product.ProductName = model.ProductName;
            product.Price = model.ProductPrice;
            product.Description = model.ProductDescription;
            product.UpdatedAt = DateTime.UtcNow;
        }
        await _productService.UpdateProductAsync(product);
        
        var existingCategories = await _productCategoryService.GetAllProductCategoriesByProductIdAsync(product.ProductID);
        var existingCategoryIds = existingCategories.Select(c => c.CategoryID).ToList();
        if (model.CategoryIds != null)
        {
            foreach (var categoryId in model.CategoryIds)
            {
                if (!existingCategoryIds.Contains(categoryId))
                {
                    var categoryEntry = new ProductCategory
                    {
                        AssignedAt = DateTime.UtcNow,
                        CategoryID = categoryId,
                        ProductID = product.ProductID,
                    };
                    await _productCategoryService.AddProductCategoryAsync(categoryEntry);
                }
            }
        }
        foreach (var category in existingCategories)
        {
            if (model.CategoryIds == null || !model.CategoryIds.Contains(category.CategoryID))
            {
                await _productCategoryService.DeleteProductCategoryAsync(category);
            }
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