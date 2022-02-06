using System;
using Xunit;
using FirstResponsiveWebAppWood.Models;
namespace FirstResponsiveWebAppTest
{
    public class UserAgeTest
    {
        [Fact]
        public void UserAge_GoodInput()
        {
            //Arrange
            UserAge age = new UserAge();
            age.Name = "Carol";
            age.BirthYear = 1985;
            int thisYear = DateTime.Now.Year;
            //Act
            int expected = thisYear - (int)age.BirthYear;
            int actual = (int)age.AgeThisYear;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
