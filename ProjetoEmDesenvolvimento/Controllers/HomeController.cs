using Microsoft.AspNetCore.Mvc;

namespace MeuCrud.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }       
    }
}