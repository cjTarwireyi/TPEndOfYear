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
            UserDTO updateUser = new UserDTO();
            UserDTO addeUser,existingUser,modifiedUser = new UserDTO();
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

            //TESTING UPDATE
            updateUser.Id = addeUser.Id;
            updateUser.username = "cj";
            updateUser.password = addeUser.password;
            updateUser.userType = 2;
            user.UpdateUser(updateUser);
            modifiedUser = user.getUser("cj", addeUser.password);
            Assert.AreEqual("cj", modifiedUser.username.Trim());
            Assert.AreEqual(password, modifiedUser.password.Trim());
            Assert.AreEqual(2, modifiedUser.userTypeDto.Id);
        }
 
      
    }
}
