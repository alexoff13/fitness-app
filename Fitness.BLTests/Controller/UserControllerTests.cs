using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            string userName = Guid.NewGuid().ToString();
            //Act
            UserController controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {   //Arrange
            string userName = Guid.NewGuid().ToString();
            DateTime birthDate = DateTime.Now.AddYears(-18);
            int weight = 90;
            int height = 200;
            string gender = "man";
            //Act
            UserController controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDate, weight, height);
            UserController controler2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controler2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controler2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controler2.CurrentUser.Weight);
            Assert.AreEqual(height, controler2.CurrentUser.Height);
            Assert.AreEqual(gender, controler2.CurrentUser.Gender.Name);
        }
    }
}