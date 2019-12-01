using EmployeeHub.Core.Models;
using EmployeeHub.DataAccess.Models;

namespace EmployeeHub.Core.Factory
{
    /// <summary>
    /// Factory to create an hourly paid employee
    /// </summary>
    public class HourlyEmployeeFactory : EmployeeFactory
    {
        public const int HoursInMonth = 120;

        /// <summary>
        /// Creates a HourlyEmployee calculating annual salary as:
        /// 120 * HourlySalary * 12
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

            var employee = new HourlyEmployee
            {
                Id = data.Id,
                Name = data.Name,
                HourlySalary = data.HourlySalary,
                AnnualSalary = data.HourlySalary * MonthsInYear * HoursInMonth,
                Role = role
            };

            return employee;
        }
    }
}
