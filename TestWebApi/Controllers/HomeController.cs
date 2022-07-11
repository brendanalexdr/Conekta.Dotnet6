using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
