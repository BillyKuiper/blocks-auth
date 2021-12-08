using NUnit.Framework;
using WebshopAuth.Controllers;
using WebshopAuth.Models;
using WebshopAuth.Services;

namespace TestProject.WebshopAuth
{
    public class Tests
    {
        private IAccount _service;

        [SetUp]
        public void Setup()
        {
            _service = new AccountDB();
        }

        [Test]
        public void loginWrongEmail()
        {
            //Arrange
            var controller = new AccountController(_service);
            string AuthToken = "Bearer: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiMCIsIm5iZiI6MTYzODg5NDczNywiZXhwIjoxNjM4ODk4MzM3fQ.bMcLbwvW0u1bXT7daDIFuqUadla-0gZ8SdYCabxYNcI";
            User u = new User();
            u.email = "a@adfgwersuigihbnweirk.nl";
            u.password = "a";
 
            //Act
            var result = controller.login(AuthToken, u);
            string noUser = "Niet gevonden";
            //Assert
            Assert.AreEqual(result, noUser);
        }

        [Test]
        public void loginWrongPassword()
        {
            //Arrange
            var controller = new AccountController(_service);
            string AuthToken = "Bearer: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiMCIsIm5iZiI6MTYzODg5NDczNywiZXhwIjoxNjM4ODk4MzM3fQ.bMcLbwvW0u1bXT7daDIFuqUadla-0gZ8SdYCabxYNcI";
            User u = new User();
            u.email = "a@a.nl";
            u.password = "aasdfjkgdfghbuiekrw";

            //Act
            var result = controller.login(AuthToken, u);
            string noUser = "Niet gevonden";
            //Assert
            Assert.AreEqual(result, noUser);
        }

        [Test]
        public void loginMissingEmail()
        {
            //Arrange
            var controller = new AccountController(_service);
            string AuthToken = "Bearer: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiMCIsIm5iZiI6MTYzODg5NDczNywiZXhwIjoxNjM4ODk4MzM3fQ.bMcLbwvW0u1bXT7daDIFuqUadla-0gZ8SdYCabxYNcI";
            User u = new User();
            u.email = null;
            u.password = "aasdfjkgdfghbuiekrw";

            //Act
            var result = controller.login(AuthToken, u);
            string noUser = "Niet gevonden";
            //Assert
            Assert.AreEqual(result, noUser);
        }

        [Test]
        public void loginMissingPassword()
        {
            //Arrange
            var controller = new AccountController(_service);
            string AuthToken = "Bearer: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiMCIsIm5iZiI6MTYzODg5NDczNywiZXhwIjoxNjM4ODk4MzM3fQ.bMcLbwvW0u1bXT7daDIFuqUadla-0gZ8SdYCabxYNcI";
            User u = new User();
            u.email = "a@a.nl";
            u.password = null;

            //Act
            var result = controller.login(AuthToken, u);
            string noUser = "Niet gevonden";
            //Assert
            Assert.AreEqual(result, noUser);
        }

        [Test]
        public void loginNoCredentials()
        {
            //Arrange
            var controller = new AccountController(_service);
            string AuthToken = "Bearer: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiMCIsIm5iZiI6MTYzODg5NDczNywiZXhwIjoxNjM4ODk4MzM3fQ.bMcLbwvW0u1bXT7daDIFuqUadla-0gZ8SdYCabxYNcI";
            User u = new User();
            u.email = null;
            u.password = null;

            //Act
            var result = controller.login(AuthToken, u);
            string noUser = "Niet gevonden";
            //Assert
            Assert.AreEqual(result, noUser);
        }
    }
}