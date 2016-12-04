using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  BusineesLogic.factories;

namespace UnitTests.factories
{
    [TestClass]
    public class TestUser
    {
        [TestMethod]
        public void creatrUserTest()
        {
            UserDTO createdUser = UserFactory.createUser("cj", "pass", 1);
            Assert.AreEqual("cj",createdUser.username);
            Assert.AreEqual("pass", createdUser.password);
            Assert.AreEqual(1, createdUser.userTypeId);
        }
    }
}
