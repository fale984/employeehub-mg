using EmployeeHub.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeHub.DataAccess.Contracts
{
    public interface IEmployeeReader
    {
        /// <summary>
        /// Retrieves the collection of employees
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BasicEmployee>> GetEmployeesAsync();
    }
}
