using FlowerDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using MigrationDataBase;
using MigrationDataBase.Records;
using Logic;
using System.Diagnostics;
using System.Data;

namespace FlowerDelivery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            try
            {
                User userS = ManagerSession.GetUser(HttpContext?.Connection?.Id ?? "ывад");
                this.ViewData["Name"] = userS.Name + " " + userS.Surname;
            }
            catch
            {
                this.ViewData["Name"] = "Неавторизованный пользователь";
            }
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
            var authentication = new Logic.Authentication();
            var user = authentication.Lout(login, password);
            if ((user) != null)
            {
                ManagerSession.RegistUser(user, HttpContext.Connection.Id);

                if(new InteractiveOfRoles().Check(user, new Admin(0, user)))
                    return Redirect("~/Admin");
                return View("OrderList", new OrderData().GetOrders());
            }
            else
                return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}