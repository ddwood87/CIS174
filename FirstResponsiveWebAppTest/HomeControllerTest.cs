using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstResponsiveWebAppWood.Controllers;
using FirstResponsiveWebAppWood.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
namespace FirstResponsiveWebAppTest
{
    public class HomeControllerTest
    {
        public UserAge SetupModel() 
        {
            //Create valid object.
            UserAge userAge = new UserAge();
            userAge.Name = "Connie";
            userAge.BirthYear = 1985;
            return userAge;
        }

        [Fact]
        public void Index_Get()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            IActionResult result = controller.Index();

            //Assert
            Assert.Equal(0, controller.ViewBag.Age);
        }

        [Fact]
        public void Index_Post()
        {
            //Arrange
            HomeController controller = new HomeController();
            UserAge userAge = SetupModel();

            //Act
            IActionResult result = controller.Index(userAge);
            
            //Assert
            Assert.Equal(userAge.Name, controller.ViewBag.Name);
            Assert.Equal(userAge.BirthYear, controller.ViewBag.BirthYear);
        }

        [Fact]
        public void UserAge_Post_GoodModel()
        {
            //Arrange
            HomeController controller = new HomeController();
            UserAge userAge = SetupModel();

            //Act
            IActionResult result = controller.UserAge(userAge);

            //Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(userAge.Name, controller.ViewBag.Name);
            Assert.Equal(userAge.AgeThisYear, controller.ViewBag.Age);
        }

        [Fact]
        public void UserAge_Post_BadModel()
        {
            //Arrange
            HomeController controller = new HomeController();
            UserAge userAge = SetupModel();
            userAge.BirthYear = 1850;
            controller.ModelState.AddModelError("AgeThisYear","age");

            //Act
            ViewResult result = (ViewResult)controller.UserAge(userAge);

            //Assert
            Assert.Equal("Index", result.ViewName);
        }
    }
}
