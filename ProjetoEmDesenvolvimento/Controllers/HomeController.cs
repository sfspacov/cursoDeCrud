using Microsoft.AspNetCore.Mvc;

namespace SiteWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}