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
        private bool Check()
        {
            try
            {
                User user = ManagerSession.GetUser(HttpContext?.Connection?.Id ?? "sd");
                if(user == null) 
                    return false;
                return new InteractiveOfRoles().Check(user, new Admin(1, user));
            }
            catch
            {
                return false;
            }
            
        }

        public IActionResult Index()
        {
            NameDisplay();
            if (Check())
                return View("ListOfSession", ManagerSession.GetUsers());
            return NotFound();
        }

        public IActionResult ListOfUser()
        {
            NameDisplay();
            if (!Check())
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
            if (!Check())
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
            if (!Check())
                return NotFound();

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
            if (Check())
                return View("NewUser");
            return NotFound();
        }

        public IActionResult ListOfFlower()
        {
            NameDisplay();
            if (!Check())
                return NotFound();
            return View("ListOfFlowers", new InteractiveFlower().Get());
        }

        public IActionResult Flower(int idFlower)
        {
            NameDisplay();
            if (!Check())
                return NotFound();

            return View((Flower)new InteractiveFlower().Get(idFlower));
        }
    }
}
