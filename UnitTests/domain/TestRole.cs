using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;

namespace UnitTests.factories
{
    [TestClass]
    public class TestRole
    {
        [TestMethod]
        public void testRole()
        {
            //Create
            RoleDTO roleDto = RoleFactory.createRole(1, "Delete,Update");
            Assert.AreEqual("Delete,Update", roleDto.roleDescription);
            Assert.AreEqual(1, roleDto.roleId);

            //Update
            RoleDTO updateRole = new RoleDTO.RoleBuilder()
                .copy(roleDto)
                .buildroleDescription("view only")
                .build();
            Assert.AreEqual(1, updateRole.roleId);
            Assert.AreNotEqual("Delete,Update", updateRole.roleDescription);
        }
         

    }
}
