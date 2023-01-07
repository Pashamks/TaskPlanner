using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TaskPlanner.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ITaskManager _taskManager;
        public TaskController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _taskManager.GetAllTasks());
        }
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskModel task)
        {
            await _taskManager.AddNewTask(task);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> CloseTask(WorkProcessModel task)
        {
            await _taskManager.CloseTask(task);
            return Ok();
        }
        [HttpPost]
        [Route("sign")]
        public async Task<IActionResult> SignTask(WorkProcessModel task)
        {
            await _taskManager.SignTaskToEmployee(task);
            return Ok();
        }

    }
}
