﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.Interface;
using BusineesLogic.factories;
using BusineesLogic.services;
using BusineesLogic.domain;
namespace UnitTests.services
{
    [TestClass]
    public class TestRoleService
    {
        [TestMethod]
        public void TestRoleServiceMethods()
        {
            IRoleService service = new RoleDAO();

            //TEST ADD ROLE
            RoleDTO createRole = RoleFactory.createRole( "read", "view only");
          bool result=  service.addRole(createRole);

          Assert.IsTrue(result);
            //TEST fINDBY ID
          RoleDTO role = service.findRole(service.getLastReocrd().roleId);
            Assert.IsNotNull(role);

            //TEST FINDALL            
            Assert.IsNotNull(service.getAllRoles());

            //TestUpdate
            RoleDTO updateRole = new RoleDTO.RoleBuilder()
            .copy(service.getLastReocrd())
            .buildroleDescription("update description")
            .build();
            service.updateRole(updateRole);
            Assert.AreEqual("update description", service.getLastReocrd().roleDescription);

            //TEST DELETE
           bool deleteResult = service.deleteRole(service.getLastReocrd().roleId);

           Assert.IsTrue(deleteResult);



        }
    }
}
