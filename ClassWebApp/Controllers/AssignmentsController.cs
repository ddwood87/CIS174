using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassWebApp.Models;
namespace ClassWebApp.Controllers
{
    public class AssignmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("{id}")]
        public IActionResult Index(int id)
        {
            Student student = new Student();
            return View("Index", student);
        }
    }
}
