using Microsoft.AspNetCore.Mvc;

namespace FlowerDelivery.Controllers
{
    public class FlowerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
