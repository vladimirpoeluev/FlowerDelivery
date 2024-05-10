using Microsoft.AspNetCore.Mvc;
using FlowerDelivery.Models;
using MigrationDataBase.Records;

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
            return View("UserOfList", new User[] 
            {
                new User(1, "имя 1", "фамилия 1", "огурец"),
                new User(2, "имя 2", "фамилия 2", "помидор"),
            });

        }
    }
}
