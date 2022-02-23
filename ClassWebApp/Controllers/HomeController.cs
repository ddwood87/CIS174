using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassWebApp.Models;

namespace ClassWebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewModel viewObject = new ViewModel();
            
            return View("Index", viewObject);
        }
        public IActionResult Index(ViewModel viewObject)
        {
            ViewData["Title"] = "Home Page";
            RedirectToAction("~/");
            return View("Index", viewObject);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Title"] = "Add";           
            return View("Edit");
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Edit";
            Student student = Student.GetStudent(id);
            ViewModel viewObject = new ViewModel(student);
            return View("Edit", viewObject);
        }

        [HttpPost]
        public IActionResult Edit(ViewModel viewObject)
        {
            
           
            //student.FirstName = firstName;
            //student.LastName = lastName;
            //student.Grade = grade;
            viewObject.Student.SaveStudent();
            viewObject.Students = Student.GetAllStudentsList();
            return View("Index", viewObject);
        }
        public IActionResult Delete(int id)
        {
            Student.DeleteStudent(id);
            return Index();
        }
        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            return View();
        }
        public IActionResult AddMaster()
        {
            Student s = new Student();
            s.Id = 0;
            s.FirstName = "Master";
            s.LastName = "Entry";
            s.Grade = "A-F";
            s.SaveStudent();
            return Index();
        }
    }
}
