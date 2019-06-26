using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoAPI;
using DemoAPI.Controllers;
using Moq;
using DemoAPI.Models;
using System.Web.Http.Results;

namespace DemoAPI.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        Mock<IRepository<User>> mock;

        [TestInitialize]
        public void TestInit()
        {
            mock = new Mock<IRepository<User>>(MockBehavior.Strict);
        }

        [TestMethod]
        public void Get_ReturnsAllUsers()
        {
            // Упорядочение
            var fakeUserList = GetFakeUsers();
            mock.Setup(e => e.GetAll()).Returns(new List<User>(fakeUserList));
            UserController controller = new UserController(mock.Object);

            // Действие
            var result = controller.Get() as OkNegotiatedContentResult<List<User>>;

            // Утверждение
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(fakeUserList.Count, result.Content.Count());
            for (int i = 0; i < fakeUserList.Count; i++)
            {
                // technically we can verify an every single property;
                Assert.AreSame(fakeUserList.ElementAt(i), result.Content.ElementAt(i));
            }
        }

        [TestMethod]
        public void GetById()
        {
            // Упорядочение
            var fakeUser = GetFakeUser();
            mock.Setup(e => e.Get(fakeUser.UserId))
                .Returns(new User { UserId = fakeUser.UserId, Username = fakeUser.Username});
            UserController controller = new UserController(mock.Object);

            // Действие
            var result = controller.Get(fakeUser.UserId) as OkNegotiatedContentResult<User>;

            // Утверждение
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(fakeUser.UserId, result.Content.UserId);
            Assert.AreEqual(fakeUser.Username, result.Content.Username);
        }

        [TestMethod]
        public void Post_ValidUser_ReturnsOkResult()
        {
            // Упорядочение
            var fakeUser = GetFakeUser();
            mock.Setup(e => e.Post(fakeUser));
            mock.Setup(e => e.Post(It.Is<User>(user => user != fakeUser)))
                .Throws<ArgumentException>();
            mock.Setup(e => e.Save());

            UserController controller = new UserController(mock.Object);

            // Действие
            var result = controller.Post(fakeUser);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(OkResult));
            mock.Verify(m => m.Save(), Times.Once);
        }

        [TestMethod]
        public void Post_InvalidUser_ReturnsInvalidModelStateResult()
        {
            // Упорядочение 
            var fakeUser = GetFakeUser();
            mock.Setup(e => e.Post(fakeUser));
            UserController controller = new UserController(mock.Object);
            controller.ModelState.AddModelError("test", "test");

            // Действие 
            var result = controller.Post(fakeUser); 

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void Put_ValidUser_ReturnsOkResult()
        {
            // Упорядочение
            var fakeUser = GetFakeUser();
            mock.Setup(e => e.Put(fakeUser));
            mock.Setup(e => e.Put(It.Is<User>(user => user != fakeUser)))
                .Throws<ArgumentException>();
            mock.Setup(e => e.Save());

            UserController controller = new UserController(mock.Object);

            // Действие
            var result = controller.Put(fakeUser);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(OkResult));
            mock.Verify(m => m.Save(), Times.Once);
        }

        [TestMethod]
        public void Put_InvalidUser_ReturnsInvalidModelStateResult()
        {
            // Упорядочение
            var fakeUser = GetFakeUser();
            mock.Setup(e => e.Put(fakeUser));
            UserController controller = new UserController(mock.Object);
            controller.ModelState.AddModelError("test", "test");

            // Действие
            var result = controller.Put(fakeUser);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void Delete_ReturnsOkResult()
        {
            // Упорядочение
            var fakeUser = GetFakeUser();
            mock.Setup(e => e.Delete(It.Is<int>(i => i == fakeUser.UserId)));
            mock.Setup(e => e.Delete(It.Is<int>(i => i != fakeUser.UserId)))
                .Throws<ArgumentOutOfRangeException>();
            mock.Setup(e => e.Save());
            UserController controller = new UserController(mock.Object);

            // Действие
            var result = controller.Delete(fakeUser.UserId); 

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(OkResult));
            mock.Verify(m => m.Save(), Times.Once);
        }

        private List<User> GetFakeUsers()
        {
            return new List<User>()
            {
                new User {UserId = 0, Username = "Valik"},
                new User {UserId = 1, Username = "Dima"},
                new User {UserId = 1, Username = "Kolya"}
            };
        }

        private User GetFakeUser()
        {
            return new User { UserId = 0, Username = "Valik" };
        }
    }
}
