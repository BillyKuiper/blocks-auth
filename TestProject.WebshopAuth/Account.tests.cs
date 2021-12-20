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

        [Test]
        public void basicRegister()
        {
            //Arrange
            var controller = new AccountController(_service);
            User u = new User();
            u.email = "unittest@unittest.com";
            u.password = "1234";
            u.adress = "Stappegoor";
            u.city = "Tilburg";
            u.firstName = "Billy";
            u.lastName = "Kuiper";
            u.housenumber = "5";

            //Act
            var result = controller.register(u);
            bool expextedResult = true;

            //Assert
            Assert.AreEqual(result, expextedResult);
        }

        [Test]
        public void basicRegisterNoEmail()
        {
            //Arrange
            var controller = new AccountController(_service);
            User u = new User();
            u.email = null;
            u.password = "1234";
            //Act
            var result = controller.register(u);
            bool expextedResult = false;

            //Assert
            Assert.AreEqual(result, expextedResult);
        }

        [Test]
        public void basicRegisterNoPassword()
        {
            //Arrange
            var controller = new AccountController(_service);
            User u = new User();
            u.email = "unittest@unittest.com";
            u.password = null;
            u.adress = "Stappegoor";
            u.city = "Tilburg";
            u.firstName = "Billy";
            u.lastName = "Kuiper";
            u.housenumber = "5";
            //Act
            var result = controller.register(u);
            bool expextedResult = false;

            //Assert
            Assert.AreEqual(result, expextedResult);
        }

        [Test]
        public void getSingleUser()
        {
            //Arrange
            var controller = new AccountController(_service);
            string AuthToken = "Bearer: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiMCIsIm5iZiI6MTYzODg5NDczNywiZXhwIjoxNjM4ODk4MzM3fQ.bMcLbwvW0u1bXT7daDIFuqUadla-0gZ8SdYCabxYNcI";

            User u2 = new User();
            u2.userId = 2;
            u2.email = "b@b.nl";
            u2.password = "b";
            u2.city = "Bergen op Zoom";
            u2.adress = "Strandplevier 16";
            u2.firstName = "Meriam";
            u2.lastName = "Doe";
            u2.addition = "";
            u2.zipcode = "4617AZ";

            //Act
            User result = controller.getUser(AuthToken);
            User expectedResult = u2;
            //Assert
            Assert.AreEqual(result.userId, expectedResult.userId);
            Assert.AreEqual(result.email, expectedResult.email);
            Assert.AreEqual(result.password, expectedResult.password);
            Assert.AreEqual(result.firstName, expectedResult.firstName);
            Assert.AreEqual(result.lastName, expectedResult.lastName);
        }

        [Test]
        public void getSingleUserNoToken()
        {
            //Arrange
            var controller = new AccountController(_service);
            string AuthToken = null;

            //Act
            User result = controller.getUser(AuthToken);
            User expectedResult = null;
            //Assert
            Assert.AreEqual(result, expectedResult);
        }

    }
}