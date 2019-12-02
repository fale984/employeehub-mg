using EmployeeHub.Core.Contracts;
using EmployeeHub.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeHub.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IHubEmployeeRepository _employerRepository;

        public EmployeeController(IHubEmployeeRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        // GET api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HubEmployee>>> GetAsync()
        {
            var employees = await _employerRepository.GetEmployeesAsync();

            return employees.ToList();
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HubEmployee>> GetAsync(int id)
        {
            var employee = (await _employerRepository.GetEmployeesAsync()).FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
    }
}