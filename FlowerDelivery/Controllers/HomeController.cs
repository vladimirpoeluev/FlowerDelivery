using FlowerDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using MigrationDataBase;
using MigrationDataBase.Records;
using Logic;
using System.Diagnostics;
using Logic.Interactive;

namespace FlowerDelivery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private void NameDisplay()
        {
            try
            {
                User userS = ManagerSession.GetUser(HttpContext?.Connection?.Id ?? "ывад");
                this.ViewData["Name"] = userS?.Name + " " + userS?.Surname;
            }
            catch
            {
                this.ViewData["Name"] = "Неавторизованный пользователь";
            }
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            NameDisplay();
            return View();
        }

        public IActionResult Privacy()
        {
            NameDisplay();
            return View();
        }

        [HttpPost]
        public IActionResult Entrance(string login, string password)
        {
            NameDisplay();
            var authentication = new Authentication();
            var user = authentication.Lout(login, password);
            if ((user) != null)
            {
                ManagerSession.RegistUser(user, HttpContext.Connection.Id);

                if(new InteractiveOfRoles().Check(user, new Admin(0, user)))
                    return Redirect("~/Admin");
                return View("OrderList", new OrderData().GetOrders());
            }
            else
            {
                ViewData["Error"] = "Были введены неверные данные";
                return View("Index");
            }
               
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}