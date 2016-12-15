using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusineesLogic.domain;
using BusineesLogic.factories;

namespace UnitTests.factories
{
    [TestClass]
    public class TestDepartment
    {
        [TestMethod]
        public void testCreateDepartment()
        {
            List<string> departmentDetails = new List<string>();
            
            departmentDetails.Add("Cleaning");
            departmentDetails.Add("Cleaner the house");
            DepartmentDTO department = DepartmentFactory.createDepartment(departmentDetails);

            Assert.AreEqual(department.departmentName,"Cleaning");
        }


        [TestMethod]
        public void testUpdateDepartment()
        {
            List<string> departmentDetails = new List<string>();

            departmentDetails.Add("Cleaning");
            departmentDetails.Add("Cleaner the house");
            DepartmentDTO department = DepartmentFactory.createDepartment(departmentDetails);
            DepartmentDTO updateDepartment = new DepartmentDTO.DepartmentBuilder()
                                               .copy(department)
                                               .buildName("I.T")
                                               .build();
            Assert.AreNotEqual(department.departmentName,updateDepartment.departmentName);

            
        }
    }
}
