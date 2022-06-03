using Microsoft.AspNetCore.Mvc;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
