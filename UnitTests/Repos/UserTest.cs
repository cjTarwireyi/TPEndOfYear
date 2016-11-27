using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.Interface;
namespace UnitTests.Repos
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            IUser user = new UserDAO() ;
            UserDTO userDto = new UserDTO();
              
             
            userDto.username="test";
            userDto.password = "pass";
            userDto.userType =1;
            user.addUser(userDto);

        }
    }
}
