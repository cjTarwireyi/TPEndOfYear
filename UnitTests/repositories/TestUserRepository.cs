﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.Interface;
using BusineesLogic.factories;
using BusineesLogic.repositories;
using BusineesLogic.repositories.Impl;

namespace UnitTests.Repos
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestUserRepo()
        {
            UserRepositoryImp user = new UserRepositoryImp();
            UserDTO deletedUser,  addeUser = new UserDTO();

            UserDTO existingUser,modifiedUser = new UserDTO();
            string username = "test";
            string password ="pass";
            UserDTO userDto = UserFactory.createUser(username, password, 1);       

            user.addUser(userDto);
            //Searching for Added User
            addeUser =   user.getUser(username, password);
            Assert.AreEqual(username,addeUser.username.Trim());
            Assert.AreEqual(password,addeUser.password.Trim() );

            //TESTING UPDATE
            UserDTO updateUser = new UserDTO.UserBuilder()
            .copy(addeUser)
            .buildUsername("cj")
            .buldUsertypeId(2)
            .build();
            
            user.UpdateUser(updateUser);

            modifiedUser = user.getUser("cj", addeUser.password);
            Assert.AreEqual("cj", modifiedUser.username.Trim());
            Assert.AreEqual(password, modifiedUser.password.Trim());
            Assert.AreEqual(2, modifiedUser.userTypeId);

            //TESTING DELETE
            existingUser = user.getUser("cj", password);
            user.Delete(existingUser.Id);
            deletedUser = user.getUser("cj", password);
            Assert.IsNull(deletedUser.username);
            Assert.IsNull(deletedUser.password);


        }
 
      
    }
}
