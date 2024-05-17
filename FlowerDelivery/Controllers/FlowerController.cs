using MigrationDataBase.Filters;
using FlowerDelivery.Models;
using Logic.Interactive;
using Microsoft.AspNetCore.Mvc;
using MigrationDataBase.Records;

namespace FlowerDelivery.Controllers
{
    public class FlowerController : Controller
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
                return new InteractiveOfRoles().Check(user, new Flower(1, user));
            }
            catch
            {
                return false;
            }

        }
        public IActionResult Index()
        {
            NameDisplay();
            if (!Check())
                return NotFound();

            return ListOfOrder();
        }

        public IActionResult ListOfOrder()
        {
            NameDisplay();
            if (!Check())
                return NotFound();

            var inter = new OrderInteractive();
            List<Order> orders = new List<Order>();
            foreach(var value in inter.Get(new FilterOrderStatus(1)))
                orders.Add((Order)value);

            return View("ListOfOrder", orders.ToArray());
        }

        public IActionResult ListOfDeliveryman()
        {
            NameDisplay();
            if (!Check())
                return NotFound();

            var inter = new DeliverymanInteractive();

            List<Deliveryman> deliverymans = new List<Deliveryman>();
            foreach (var value in inter.Get())
                deliverymans.Add((Deliveryman)value);
            return View(deliverymans.ToArray());
           
        }
    }
}
