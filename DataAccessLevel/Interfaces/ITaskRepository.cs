using DataAccessLevel.Models;

namespace DataAccessLevel.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllAsync();
        Task AddAsync(TaskModel task);
        Task UpdateAsync(TaskModel task);
        Task DeleteAsync(TaskModel task);
    }
}
