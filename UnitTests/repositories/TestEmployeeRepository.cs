using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.repositories.Impl;
using System.Collections.Generic;
using BusineesLogic.factories;

namespace UnitTests.repositories
{
    [TestClass]
    public class TestEmployeeRepository
    {
        private EmployeeDTO result;
        private EmployeeRepositoryImpl repo = new EmployeeRepositoryImpl();
        [TestMethod]
        public void testCreateUpdateRepository()
        {
            List<string> employeeDetails = new List<string>();
            employeeDetails.Add("Shireen");
            employeeDetails.Add("Wilkinson");
            employeeDetails.Add("0783588370");
            employeeDetails.Add("Sparrow");
            employeeDetails.Add("Rocklands");
            employeeDetails.Add("7798");
            EmployeeDTO employee = EmployeeFactory.createEmployee(employeeDetails);
            
            //insert
            repo.save(employee);
            result = repo.getLastReocrd();
            int id = result.employeeNumber;
            Assert.IsNotNull(result);

            //updating
            EmployeeDTO updateEmployee = new EmployeeDTO.EmployeeBuilder()
                                                        .copy(result)
                                                        .empName("Siraaj")
                                                        .build();
            result = repo.findByID(id);
           // Assert.AreEqual(result.employeeName.Trim(),"Siraaj");


            //delete
            repo.delete(id);
            result = repo.findByID(id);
            Assert.IsNull(result);
        }
    }
}
