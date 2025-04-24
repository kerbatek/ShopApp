using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopApp.Models.Catalog;
using ShopApp.Services.Catalog.Interfaces;
using ShopApp.ViewModels;

namespace ShopApp.Controllers;

[Route("inventory")]
public class InventoryController : Controller
{
    private readonly IInventoryService _inventoryService;
    private readonly IProductService _productService;

    public InventoryController(IInventoryService inventoryService,  IProductService productService)
    {
        _inventoryService = inventoryService;
        _productService = productService;
    }
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var model = await _inventoryService.GetAllInventoriesWithProductNamesAsync();
        return View(model);
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
        var vm = new InventoryViewModel();
        var products = await _productService.GetAllProductsAsync();
        vm.Products = products;
        
        return View(vm);
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(InventoryViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            vm.Products = await _productService.GetAllProductsAsync();
            return View(vm);
        }
        
        var newInventory = new Inventory
        {
            ProductID = vm.ProductId,
            Quantity  = vm.Quantity,
        };
        try
        {
            await _inventoryService.AddInventoryAsync(newInventory);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError("", ex.Message);
            var products = await _productService.GetAllProductsAsync();
            vm.Products = products;
        
            return View(vm);
            
        }
    }

    [HttpGet("edit")]
    public async Task<IActionResult> Edit(int id)
    {
        var vm = await _inventoryService.GetInventoryWithProductNameAsync(id);
        if (vm == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(vm);
    }

    [HttpPost("edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(InventoryViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        
        try
        {
            await _inventoryService.UpdateInventoryAsync(vm.InventoryId, vm.Quantity);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(vm);
        }
        
    }
    
    [HttpPost("delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            await _inventoryService.DeleteInventoryByIdAsync(id);

        }
        return RedirectToAction(nameof(Index));
    }
}