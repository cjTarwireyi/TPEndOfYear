﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.Interface;
using BusineesLogic.factories;
using BusineesLogic.services;
using BusineesLogic.domain;
namespace UnitTests.services
{
    [TestClass]
    public class RoleTest
    {
        [TestMethod]
        public void TestRole()
        {
            IRoleService service = new RoleDAO();

            RoleDTO role = service.findRole(1);
            Assert.IsNotNull(role);
        }
    }
}
