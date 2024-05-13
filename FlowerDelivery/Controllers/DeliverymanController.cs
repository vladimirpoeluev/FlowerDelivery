using Microsoft.AspNetCore.Mvc;

namespace FlowerDelivery.Controllers
{
    public class DeliverymanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
