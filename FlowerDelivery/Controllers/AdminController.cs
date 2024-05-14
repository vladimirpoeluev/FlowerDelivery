using Microsoft.AspNetCore.Mvc;
using FlowerDelivery.Models;
using MigrationDataBase.Records;
using Logic.Interactive;

namespace FlowerDelivery.Controllers
{
    public class AdminController : Controller
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
        public IActionResult Index()
        {
            NameDisplay();

            User user = ManagerSession.GetUser(HttpContext.Connection.Id);
            if (new InteractiveOfRoles().Check(user,new Admin(1,  ManagerSession.GetUser(HttpContext.Connection.Id))))
                return View("ListOfSession", ManagerSession.GetUsers());
            return NotFound();
        }

        public IActionResult ListOfUser()
        {
            NameDisplay();
            User userS = ManagerSession.GetUser(HttpContext.Connection.Id);
            if (!new InteractiveOfRoles().Check(userS, new Admin(1,userS)))
                return NotFound();

            var user = new UserInteractive();
            var result = new List<User>(); 
            foreach(var u in user.Get())
                result.Add((User) u);
            return View("UserOfList", result.ToArray());

        }

        [HttpPost]
        public IActionResult ListOfUser(User user)
        {
            NameDisplay();
            User userS = ManagerSession.GetUser(HttpContext.Connection.Id);
            if (!new InteractiveOfRoles().Check(userS, new Admin(1, user)))
                return NotFound();

            UserInteractive userInteractive = new UserInteractive();
            userInteractive.Add(user);

            var result = new List<User>();

            foreach (var u in userInteractive.Get())
                result.Add((User)u);

            return View("UserOfList", result.ToArray());
        }

        public IActionResult ListOfOrder()
        {
            NameDisplay();
            var list = new List<Order>();
            foreach(Order order in new OrderInteractive().Get())
            {
                list.Add(order);
            }

            return View("ListOfOrder", list.ToArray());
        }

        public IActionResult NewUser()
        {
            NameDisplay();
            User user = ManagerSession.GetUser(HttpContext.Connection.Id);
            if (new InteractiveOfRoles().Check(user, new Admin(1, ManagerSession.GetUser(HttpContext.Connection.Id))))
                return View("NewUser");
            return NotFound();
        }
    }
}
