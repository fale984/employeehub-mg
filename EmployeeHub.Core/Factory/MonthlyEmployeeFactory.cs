using EmployeeHub.Core.Models;
using EmployeeHub.DataAccess.Models;

namespace EmployeeHub.Core.Factory
{
    /// <summary>
    /// Factory to create a monthly paid employee
    /// </summary>
    public class MonthlyEmployeeFactory : EmployeeFactory
    {
        /// <summary>
        /// Creates a MonthlyEmployee calculating annual salary as:
        /// MonthtlySalary * 12
        /// </summary>
        /// <param name="data">Basic employee information</param>
        /// <returns>Converted user with annual salary</returns>
        public override HubEmployee Create(BasicEmployee data)
        {
            var role = new HubRole
            {
                Id = data.RoleId,
                Name = data.Name,
                Description = data.RoleDescription
            };

            var employee = new MonthlyEmployee
            {
                Id = data.Id,
                Name = data.Name,
                MonthlySalary = data.MonthlySalary,
                AnnualSalary = data.MonthlySalary * MonthsInYear,
                Role = role
            };

            return employee;
        }
    }
}
