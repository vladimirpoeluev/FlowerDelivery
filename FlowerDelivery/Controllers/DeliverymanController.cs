using FlowerDelivery.Models;
using Logic.Interactive;
using Microsoft.AspNetCore.Mvc;
using MigrationDataBase.Records;
using MigrationDataBase.Filters;

namespace FlowerDelivery.Controllers
{
    public class DeliverymanController : Controller
    {
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
        private bool Check()
        {
            try
            {
                User user = ManagerSession.GetUser(HttpContext?.Connection?.Id ?? "sd");
                if (user == null)
                    return false;
                return new InteractiveOfRoles().Check(user, new Deliveryman(1, user));
            }
            catch
            {
                return false;
            }

        }
        public IActionResult Index()
        {
            NameDisplay();
            if(!Check())
                return NotFound();

            var inter = new OrderInteractive();
            List<Order> orders = new List<Order>();
            foreach (var value in inter.Get(new FilterOrderStatus(3)))
                orders.Add((Order)value);

            return View("ListOfOrder", orders.ToArray());
        }

        public IActionResult ListOfOrder()
        {
            return Index();
        }

        public IActionResult OrderOfDelivery(int idOrder)
        {
            return View();
        }
    }
}
