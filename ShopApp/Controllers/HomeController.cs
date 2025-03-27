using Microsoft.AspNetCore.Mvc;

namespace ShopApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return RedirectToAction("LoginPage", "Account");
        }
        
        [HttpGet("/home")]
        public IActionResult HomePage()
        {
            return View();
        }
    }
}