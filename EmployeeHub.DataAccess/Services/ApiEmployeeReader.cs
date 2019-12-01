using EmployeeHub.DataAccess.Contracts;
using EmployeeHub.DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeHub.DataAccess.Services
{
    /// <summary>
    /// Implements the IEmployeeReader interface calling the external API
    /// </summary>
    public class ApiEmployeeReader : IEmployeeReader
    {
        private readonly string _endPointUrl;

        private readonly HttpClient _client;

        public ApiEmployeeReader(string endPointUrl)
        {
            _endPointUrl = endPointUrl;
            _client = new HttpClient();
        }

        public async Task<IEnumerable<BasicEmployee>> GetEmployeesAsync()
        {
            // Try to get employees from the service
            try
            {
                var response = await _client.GetAsync(_endPointUrl);
                if (response.IsSuccessStatusCode)
                {
                    var employeesString = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<IEnumerable<BasicEmployee>>(employeesString);
                }
            }
            catch (Exception)
            {
            }

            // Return empty collection if an error occurred
            return Enumerable.Empty<BasicEmployee>();
        }
    }
}
