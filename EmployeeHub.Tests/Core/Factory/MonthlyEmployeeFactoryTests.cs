using EmployeeHub.Core.Factory;
using EmployeeHub.Core.Models;
using EmployeeHub.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeHub.Tests.Core.Factory
{
    [TestClass]
    public class MonthlyEmployeeFactoryTests
    {
        [TestMethod]
        public void MonthlyEmployeeFactory_Create_CreatesEmployee()
        {
            // arrange
            var basicEmployee = new BasicEmployee
            {
                Id = 50,
                Name = "Employee 2",
                ContractTypeName = "MonthlySalaryEmployee",
                RoleId = 200,
                RoleName = "Role Name",
                RoleDescription = "Role Description",
                HourlySalary = 160,
                MonthlySalary = 220
            };
            var expectedSalary = basicEmployee.MonthlySalary * 12;
            var factory = new MonthlyEmployeeFactory();

            // act
            var hourlyEmployee = factory.Create(basicEmployee);

            // assert
            Assert.IsNotNull(hourlyEmployee);
            Assert.IsInstanceOfType(hourlyEmployee, typeof(MonthlyEmployee));
            Assert.AreEqual(basicEmployee.Id, hourlyEmployee.Id);
            Assert.AreEqual(basicEmployee.RoleId, hourlyEmployee.Role.Id);
            Assert.AreEqual(expectedSalary, hourlyEmployee.AnnualSalary);
        }
    }
}
