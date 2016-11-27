using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.Interface;
namespace UnitTests.Repos
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void InsertUserTest()
        {
            
            IUser user = new UserDAO() ;
            UserDTO userDto = new UserDTO();
            UserDTO addeUser,existingUser = new UserDTO();
            string username = "test";
            string password ="pass";
            //Deleting test Data
            existingUser = user.getUser(username, password);
            user.Delete(existingUser.Id);

            //Initalising new user
            userDto.username=username;
            userDto.password = password;
            userDto.userType =1;
            user.addUser(userDto);
            //Searching for Added User
            addeUser =   user.getUser(username, password);
            Assert.AreEqual(username,addeUser.username.Trim());
            Assert.AreEqual(password,addeUser.password.Trim() );

        }
    }
}
