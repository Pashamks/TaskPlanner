
using DataAccessLevel.Models;

namespace DataAccessLevel.Interfaces
{
    public interface IWorkProcessRepository
    {
        Task<List<WorkProcessEntity>> GetAllAsync();
        Task AddAsync(WorkProcessEntity work);
        Task UpdateAsync(WorkProcessEntity work);
        Task DeleteAsync(WorkProcessEntity work);
    }
}
