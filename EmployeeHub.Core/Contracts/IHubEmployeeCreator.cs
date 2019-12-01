using EmployeeHub.Core.Models;
using EmployeeHub.DataAccess.Models;

namespace EmployeeHub.Core.Contracts
{
    /// <summary>
    /// Groups all the factories and applies the required for each contract type
    /// </summary>
    public interface IHubEmployeeCreator
    {
        /// <summary>
        /// Creates a HubEmployee with the proper factory
        /// </summary>
        /// <param name="employeeData">Basic employee info</param>
        /// <returns>Properly created employee</returns>
        HubEmployee CreateEmployee(BasicEmployee employeeData);
    }
}
