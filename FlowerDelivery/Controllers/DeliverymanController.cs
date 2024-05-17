using FlowerDelivery.Models;
using Logic.Interactive;
using Microsoft.AspNetCore.Mvc;
using MigrationDataBase.Records;
using MigrationDataBase.Filters;
using System.Security.Cryptography.Xml;

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
            var list = new List<Order>();
            foreach (IRecord record in inter.Get(new FilterOrderStatus(3)))
                list.Add((Order) record);

            return View("ListOfOrder", list.ToArray());
        }

        public IActionResult ListOfOrder()
        {
            return Index();
        }

        public IActionResult OrderOfDelivery(int idOrder)
        {
            NameDisplay();
            if (!Check())
                return NotFound();
            Order order = (Order)new OrderInteractive().Get(idOrder);
            
            var newOrder = new Order(order.Id, order.Client, order.Time, order.AddressShop, order.Flower, 
                                    (Deliveryman)new DeliverymanInteractive().Get(new FilterByUser(ManagerSession.GetUser(HttpContext?.Connection?.Id ?? "ывад"))), 
                                    order.OrderStatus);
            var inter = new OrderInteractive();

            inter.Set(order, newOrder);

            return View("OrderOfDeliveryman", order);
        }

        public IActionResult SetStatusOrder(int idOrder)
        {
            NameDisplay();
            if (!Check())
                return NotFound();

            Order order = (Order)new OrderInteractive().Get(idOrder);
            var newOrder = new Order(order.Id, order.Client, order.Time, order.AddressShop, order.Flower, order.Deliveryman, new OrderStatusInteractive().Get(4));
            var inter = new OrderInteractive();

            inter.Set(order, newOrder);

            return Index();
        }
    }
}
