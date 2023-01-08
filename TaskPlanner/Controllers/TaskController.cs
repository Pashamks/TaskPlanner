using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TaskPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskManager _taskManager;
        public TaskController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }
        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _taskManager.GetAllTasks());
        }
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody]TaskModel task)
        {
            await _taskManager.AddNewTask(task);
            return Ok();
        }
        [Route("close")]
        [HttpPut]
        public async Task<IActionResult> CloseTask(WorkProcessModel task)
        {
            await _taskManager.CloseTask(task);
            return Ok();
        }
        [HttpPost]
        [Route("sign")]
        public async Task<IActionResult> SignTask([FromBody] WorkProcessModel task)
        {
            await _taskManager.SignTaskToEmployee(task);
            return Ok();
        }

    }
}
