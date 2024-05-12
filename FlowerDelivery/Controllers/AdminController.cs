using Microsoft.AspNetCore.Mvc;
using FlowerDelivery.Models;
using MigrationDataBase.Records;
using Logic;

namespace FlowerDelivery.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (ManagerSession.GetUser(HttpContext.Connection.Id).Surname == "Admin")
                return View("ListOfSession", ManagerSession.GetUsers());
            return NotFound();
        }

        public IActionResult ListOfUser()
        {
            if (ManagerSession.GetUser(HttpContext.Connection.Id).Surname != "Admin")
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
            if (ManagerSession.GetUser(HttpContext.Connection.Id).Surname != "Admin")
                return NotFound();

            UserInteractive userInteractive = new UserInteractive();
            userInteractive.Add(user);

            var result = new List<User>();

            foreach (var u in userInteractive.Get())
                result.Add((User)u);

            return View("UserOfList", result.ToArray());
        }

        public IActionResult NewUser()
        {
            if (ManagerSession.GetUser(HttpContext.Connection.Id).Surname == "Admin")
                return View("NewUser");
            return NotFound();
        }
    }
}
