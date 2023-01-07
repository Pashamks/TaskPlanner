using DataAccessLevel.Models;

namespace DataAccessLevel.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskEntity>> GetAllAsync();
        Task AddAsync(TaskEntity task);
        Task UpdateAsync(TaskEntity task);
        Task DeleteAsync(TaskEntity task);
    }
}
