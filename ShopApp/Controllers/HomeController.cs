using Microsoft.AspNetCore.Mvc;

namespace ShopApp.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(HomePage));
        }
        
        [HttpGet("home")]
        public IActionResult HomePage()
        {
            return View();
        }
    }
}