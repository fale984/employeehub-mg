using EmployeeHub.Core.Contracts;
using EmployeeHub.Core.Models;
using EmployeeHub.Core.Services;
using EmployeeHub.DataAccess.Contracts;
using EmployeeHub.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeHub.Tests.Core.Services
{
    [TestClass]
    public class HubEmployeeRepositoryTests
    {
        private Mock<IEmployeeReader> _employeeReaderMock;

        private Mock<IHubEmployeeCreator> _hubConverterMock;

        [TestInitialize]
        public void TestInit()
        {
            var basicEmps = new List<BasicEmployee>
            {
                new BasicEmployee { Id = 2 },
                new BasicEmployee { Id = 4 },
                new BasicEmployee { Id = 6 }
            };

            _employeeReaderMock = new Mock<IEmployeeReader>();
            _employeeReaderMock.Setup(x => x.GetEmployeesAsync())
                .ReturnsAsync(basicEmps);

            // Mock function, here the actual conversion is not important
            _hubConverterMock = new Mock<IHubEmployeeCreator>();
            _hubConverterMock.Setup(x => x.CreateEmployee(It.IsAny<BasicEmployee>()))
                .Returns((BasicEmployee emp) => emp.Id < 5 ? new HourlyEmployee() : null);
        }

        [TestMethod]
        public async Task HubEmployeeRepository_GetEmployeesAsync_RetrievesDataAsync()
        {
            // arrange
            var hubRepository = new HubEmployeeRepository(_employeeReaderMock.Object, _hubConverterMock.Object);

            // act
            var hubEmployees = await hubRepository.GetEmployeesAsync();

            // assert
            Assert.IsNotNull(hubEmployees);
            Assert.AreEqual(2, hubEmployees.Count());
            _employeeReaderMock.Verify(x => x.GetEmployeesAsync(), Times.Once());
            _hubConverterMock.Verify(x => x.CreateEmployee(It.IsAny<BasicEmployee>()), Times.Exactly(3));
        }
    }
}
