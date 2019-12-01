using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeHub.DataAccess.Models
{
    /// <summary>
    /// Class to map the Employee API entities
    /// </summary>
    public class BasicEmployee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContractTypeName { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public double HourlySalary { get; set; }

        public double MonthlySalary { get; set; }
    }
}
