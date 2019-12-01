using EmployeeHub.Core.Models;
using EmployeeHub.DataAccess.Models;

namespace EmployeeHub.Core.Factory
{
    /// <summary>
    /// Base Factory class to create different employees
    /// </summary>
    public abstract class EmployeeFactory
    {
        public const int MonthsInYear = 12;

        /// <summary>
        /// Creates an employee from the provided data
        /// </summary>
        /// <param name="data">Basic employee information</param>
        /// <returns>Converted user with annual salary</returns>
        public abstract HubEmployee Create(BasicEmployee data);
    }
}
