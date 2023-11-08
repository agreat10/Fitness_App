using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness_App.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_App.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var gender = "man";
            var birthDate = DateTime.Now.AddYears(-18);
            double weight = 90;
            double height = 190;
            //Act
            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);

        }
    }
}