
using DataAccessLevel.Models;

namespace DataAccessLevel.Interfaces
{
    public interface IWorkProcessRepository
    {
        Task<List<WorkProcessModel>> GetAllAsync();
        Task AddAsync(WorkProcessModel work);
        Task UpdateAsync(WorkProcessModel work);
        Task DeleteAsync(WorkProcessModel work);
    }
}
