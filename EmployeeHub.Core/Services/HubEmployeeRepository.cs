using EmployeeHub.Core.Contracts;
using EmployeeHub.Core.Models;
using EmployeeHub.DataAccess.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeHub.Core.Services
{
    /// <summary>
    /// Retrieves basic employees and converts them to hub employees
    /// </summary>
    public class HubEmployeeRepository : IHubEmployeeRepository
    {
        private readonly IEmployeeReader _sourceReader;

        private readonly IHubEmployeeCreator _employeeCreator;

        public HubEmployeeRepository(IEmployeeReader sourceReader, IHubEmployeeCreator employeeCreator)
        {
            _sourceReader = sourceReader;
            _employeeCreator = employeeCreator;
        }

        public async Task<IEnumerable<HubEmployee>> GetEmployeesAsync()
        {
            var employees = new List<HubEmployee>();

            // Retrieve external basic employees
            var basicEmployees = await _sourceReader.GetEmployeesAsync();

            // Transform each basic employee to a hub employee
            foreach (var basic in basicEmployees)
            {
                var hubEmployee = _employeeCreator.CreateEmployee(basic);

                // Only keep the properly converted employees
                if (hubEmployee != null)
                {
                    employees.Add(hubEmployee);
                }
            }

            return employees;
        }
    }
}
