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
            //CREATE
            UserDTO createdUser = UserFactory.createUser("cj", "pass", 1);
            Assert.AreEqual("cj",createdUser.username);
            Assert.AreEqual("pass", createdUser.password);
            Assert.AreEqual(1, createdUser.userTypeId);

            //UPDATE
            UserDTO updateUser = new UserDTO.UserBuilder()
            .copy(createdUser)
            .buildPassword("password")
            .build();
            Assert.AreEqual("cj", updateUser.username);
            Assert.AreEqual("password", updateUser.password);
        }
    }
}
