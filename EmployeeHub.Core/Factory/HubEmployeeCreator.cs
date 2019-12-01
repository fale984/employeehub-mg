using EmployeeHub.Core.Contracts;
using EmployeeHub.Core.Models;
using EmployeeHub.DataAccess.Models;
using System.Collections.Generic;

namespace EmployeeHub.Core.Factory
{
    /// <summary>
    /// Employee Creator
    /// Keeps the factories in a dictionary and selects the corresponding to the contract
    /// </summary>
    public class HubEmployeeCreator : IHubEmployeeCreator
    {
        private readonly Dictionary<string, EmployeeFactory> _factories;

        public HubEmployeeCreator()
        {
            _factories = new Dictionary<string, EmployeeFactory>
            {
                {"HourlySalaryEmployee" , new HourlyEmployeeFactory()},
                {"MonthlySalaryEmployee" , new MonthlyEmployeeFactory()}
            };
        }

        public HubEmployee CreateEmployee(BasicEmployee employeeData)
        {
            // Select the factory according to the Contract Type
            if (_factories.ContainsKey(employeeData.ContractTypeName))
            {
                return null;
            }
            else
            {
                return _factories[employeeData.ContractTypeName].Create(employeeData);
            }
        }
    }
}
