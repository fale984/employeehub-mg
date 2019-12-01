using EmployeeHub.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeHub.Core.Contracts
{
    /// <summary>
    /// Retrieves basic employees and converts them to hub employees
    /// </summary>
    public interface IHubEmployeeRepository
    {
        /// <summary>
        /// Retrieves all the hub employees
        /// </summary>
        /// <returns>Converted employees</returns>
        Task<IEnumerable<HubEmployee>> GetEmployeesAsync();
    }
}
