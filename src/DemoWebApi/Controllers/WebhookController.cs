using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    public class WebhookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
