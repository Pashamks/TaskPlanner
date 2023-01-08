using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TaskPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _employeeManager.GetEmployees());
        }
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody]EmployeeModel employee)
        {
            await _employeeManager.AddEmployee(employee);
            return Ok();
        }
       
    }
}
