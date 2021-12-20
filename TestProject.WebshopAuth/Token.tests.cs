using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAuth.Controllers;

namespace TestProject.WebshopAuth
{
    class Token
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CreateToken()
        {
            //Arrange
            var controller = new TokenController();

            //Act
            dynamic result = controller.CreateToken(1,0);
            //Assert
            Assert.IsNotNull(result.Value);
        }

        [Test]
        public void CreateTokenNoId()
        {
            //Arrange
            var controller = new TokenController();

            //Act
            dynamic result = controller.CreateToken(0, 0);
            int expectedResult = 400;

            //Assert
            Assert.AreEqual(result.StatusCode, expectedResult);
        }

        [Test]
        public void CreateTokenNoRole()
        {
            //Arrange
            var controller = new TokenController();

            //Act
            dynamic result = controller.CreateToken(0, 0);
            int expectedResult = 400;

            //Assert
            Assert.AreEqual(result.StatusCode, expectedResult);
        }

    }
}
