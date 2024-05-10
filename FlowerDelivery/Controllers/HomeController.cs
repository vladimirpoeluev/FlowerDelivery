using FlowerDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using MigrationDataBase;
using System.Diagnostics;

namespace FlowerDelivery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrance(string login, string password)
        {
            if(ManagerSession.RegistUser(login, password, HttpContext.Connection.Id))
                return View("OrderList", new OrderData().GetOrders());
            else return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}