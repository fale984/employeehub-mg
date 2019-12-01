using EmployeeHub.Core.Factory;
using EmployeeHub.Core.Models;
using EmployeeHub.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeHub.Tests.Core.Factory
{
    [TestClass]
    public class HourlyEmployeeFactoryTests
    {
        [TestMethod]
        public void HourlyEmployeeFactory_Create_CreatesEmployee()
        {
            // arrange
            var basicEmployee = new BasicEmployee
            {
                Id = 100,
                Name = "Employee X",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 300,
                RoleName = "Role Name",
                RoleDescription = "Role Description",
                HourlySalary = 150,
                MonthlySalary = 200
            };
            var expectedSalary = basicEmployee.HourlySalary * 120 * 12;
            var factory = new HourlyEmployeeFactory();

            // act
            var hourlyEmployee = factory.Create(basicEmployee);

            // assert
            Assert.IsNotNull(hourlyEmployee);
            Assert.IsInstanceOfType(hourlyEmployee, typeof(HourlyEmployee));
            Assert.AreEqual(basicEmployee.Id, hourlyEmployee.Id);
            Assert.AreEqual(basicEmployee.RoleId, hourlyEmployee.Role.Id);
            Assert.AreEqual(expectedSalary, hourlyEmployee.AnnualSalary);
        }
    }
}
