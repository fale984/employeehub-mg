using EmployeeHub.DataAccess.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeHub.Tests.DataAccess.Services
{
    [TestClass]
    public class ApiEmployerReaderTests
    {
        [TestMethod]
        public async Task ApiEmployerReader_GetEmployeesAsync_CanAccessService()
        {
            // arrange
            var endpoint = "http://masglobaltestapi.azurewebsites.net/api/Employees";
            var employeeReader = new ApiEmployeeReader(endpoint);

            // act
            var employees = await employeeReader.GetEmployeesAsync();

            // assert
            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Count() > 0);
        }

        [TestMethod]
        public async Task ApiEmployerReader_GetEmployeesAsync_ReturnsEmptyOnServiceError()
        {
            // arrange
            var endpoint = "/api/Employees";
            var employeeReader = new ApiEmployeeReader(endpoint);

            // act
            var employees = await employeeReader.GetEmployeesAsync();

            // assert
            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Count() == 0);
        }
    }
}
