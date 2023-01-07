using BusinessLogicLevel.Models;

namespace BusinessLogicLevel.Interfaces
{
    public interface ITaskManager
    {
        public Task AddNewTask(TaskModel task);
        public Task CloseTask(WorkProcessModel task);
        public Task SignTaskToEmployee(WorkProcessModel work);
        public Task<List<TaskModel>> GetAllTasks();
    }
}
