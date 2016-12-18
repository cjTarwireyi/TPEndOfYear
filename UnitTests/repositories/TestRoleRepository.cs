using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.repositories;
using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;
namespace UnitTests.repositories
{
    [TestClass]
    public class TestRoleRepository
    {
        [TestMethod]
        public void TestRoleRepo()
        {
            RoleRepositoryImpl repo = new RoleRepositoryImpl();

            //TEST ADD ROLE
            RoleDTO createRole = RoleFactory.createRole("read", "view only");
            bool result = repo.addRole(createRole);

            Assert.IsTrue(result);
            //TEST fINDBY ID
            RoleDTO role = repo.findByID(repo.getLastReocrd().roleId);
            Assert.IsNotNull(role);

            //TEST FINDALL            
            Assert.IsNotNull(repo.getAllRoles());

            //TestUpdate
            RoleDTO updateRole = new RoleDTO.RoleBuilder()
            .copy(repo.getLastReocrd())
            .buildroleDescription("update description")
            .build();
            repo.updateRole(updateRole);
            Assert.AreEqual("update description", repo.getLastReocrd().roleDescription);

            //TEST DELETE
            bool deleteResult = repo.deleteRole(repo.getLastReocrd().roleId);

            Assert.IsTrue(deleteResult);



        }
    }
}
