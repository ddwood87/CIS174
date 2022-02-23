using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassWebApp.Models;
namespace ClassWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("[area]")]
        public IActionResult Index()
        {

            return View("Index");
        }
        public IActionResult Register()
        {

            return View("Edit");
        }

        [HttpPost]
        public IActionResult Edit(ViewModel viewObject)
        {
            viewObject.User.SaveUser();
            return View("Index", viewObject);
        }
        [HttpPost]
        public IActionResult LogIn(ViewModel viewObject)
        {
            string userName = viewObject.User.UserName;
            string password = viewObject.User.Password;
            if (Models.User.Exists(userName))
            {
                Models.User u = Models.User.GetUser(userName);
                if (u.Password.Equals(password))
                {
                    viewObject.User = u;
                }
            }
            return BackToMain(viewObject);
        }
        [HttpGet]
        public IActionResult BackToMain()
        {
            return new ClassWebApp.Controllers.HomeController().Index();
        }
        public IActionResult BackToMain(ViewModel viewObject)
        {
            return new ClassWebApp.Controllers.HomeController().Index(viewObject);
        }
    }
}
