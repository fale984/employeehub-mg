using EmployeeHub.Core.Factory;
using EmployeeHub.Core.Models;
using EmployeeHub.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeHub.Tests.Core.Factory
{
    [TestClass]
    public class HubEmployeeCreatorTests
    {
        [TestMethod]
        public void HubEmployeeCreator_CreateEmployee_CanCreateHourlyEmployee()
        {
            // arrange
            var basicEmployee = new BasicEmployee
            {
                Id = 12,
                ContractTypeName = "HourlySalaryEmployee"
            };
            var creator = new HubEmployeeCreator();

            // act
            var hubEmployee = creator.CreateEmployee(basicEmployee);

            // assert
            Assert.IsNotNull(hubEmployee);
            Assert.IsInstanceOfType(hubEmployee, typeof(HourlyEmployee));
            Assert.AreEqual(basicEmployee.Id, hubEmployee.Id);
        }

        [TestMethod]
        public void HubEmployeeCreator_CreateEmployee_CanCreateMonthlyEmployee()
        {
            // arrange
            var basicEmployee = new BasicEmployee
            {
                Id = 34,
                ContractTypeName = "MonthlySalaryEmployee"
            };
            var creator = new HubEmployeeCreator();

            // act
            var hubEmployee = creator.CreateEmployee(basicEmployee);

            // assert
            Assert.IsNotNull(hubEmployee);
            Assert.IsInstanceOfType(hubEmployee, typeof(MonthlyEmployee));
            Assert.AreEqual(basicEmployee.Id, hubEmployee.Id);
        }

        [TestMethod]
        public void HubEmployeeCreator_CreateEmployee_ReturnsNullWithRandomContract()
        {
            // arrange
            var basicEmployee = new BasicEmployee
            {
                Id = 56,
                ContractTypeName = Guid.NewGuid().ToString()
            };
            var creator = new HubEmployeeCreator();

            // act
            var hubEmployee = creator.CreateEmployee(basicEmployee);

            // assert
            Assert.IsNull(hubEmployee);
        }
    }
}
