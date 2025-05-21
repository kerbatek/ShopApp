using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Exceptions;
using ShopApp.ViewModels;

namespace ShopApp.Controllers;

[Route("Error")]
public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    [Route("")]
    public IActionResult Index()
    {
        var vm = new ErrorViewModel
        {
            StatusCode = 500,
            Message = "Oops! Something went wrong. Please try again later or contact support.",
        };
        
        var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        var path = feature?.Path ?? string.Empty;
        var query = HttpContext.Request.QueryString.Value ?? string.Empty;

        _logger.LogError("Error occured for request {Path}{Query}", path, query);
        
        var exception = feature?.Error;
        if (exception is HttpResponseException httpException)
        {
            if (httpException.DisplayError)
            {
                vm = new ErrorViewModel
                {
                    StatusCode = httpException.StatusCode,
                    Message = httpException.Message,
                }; 
            }
            _logger.LogError("Error details: {Message}, {StatusCode}", httpException.Message, httpException.StatusCode);
        }
        
        return View("Error", vm);
    }
}