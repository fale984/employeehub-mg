namespace EmployeeHub.Core.Models
{
    public abstract class HubEmployee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double AnnualSalary { get; set; }

        public HubRole Role { get; set; }
    }
}
