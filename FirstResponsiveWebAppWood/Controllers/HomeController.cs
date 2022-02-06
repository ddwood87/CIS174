/***************************************************************
* Name : PROGRAM NAME
* Author: Dominic Wood
* Created : 01/16/2021
* Course: CIS 174 - Advanced C# Programming
* Version: 1.0
* OS: Windows 10
* IDE: Visual Studio 2019
* Copyright : This is my own original work 
* based on specifications issued by our instructor.
* Description : An app that takes a user's name and birth year
*               and tells them their age this year.
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstResponsiveWebAppWood.Models;
namespace FirstResponsiveWebAppWood.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Age = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserAge model)
        {
            ViewBag.Name = model.Name;
            ViewBag.BirthYear = model.BirthYear;
            return View("Index", model);
        }
        
        [HttpPost]
        public IActionResult UserAge(UserAge model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Name = model.Name;
                ViewBag.Age = model.AgeThisYear;
                return View(model);
            }
            else
            {
                return Index(model);
            }
        }        
    }
}
