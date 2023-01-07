using DataAccessLevel.Interfaces;
using DataAccessLevel.Models;

namespace DataAccessLevel.Repositories
{
    public class WorkProcessRepository : IWorkProcessRepository
    {
        private EfCoreDbContext GetContext()
        {
            return new EfCoreDbContext();
        }
        public async Task AddAsync(WorkProcessEntity work)
        {
            using (var context = GetContext())
            {
                context.WorkProcess.Add(work);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(WorkProcessEntity work)
        {
            using (var context = GetContext())
            {
                context.WorkProcess.Remove(work);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<WorkProcessEntity>> GetAllAsync()
        {
            using (var context = GetContext())
            {
                return context.WorkProcess.ToList();
            }
        }

        public async Task UpdateAsync(WorkProcessEntity work)
        {
            using (var context = GetContext())
            {
                var workOld = context.WorkProcess.First(x => x.Id == work.Id);
                workOld.Status = work.Status;
                //workOld.TaskId = work.TaskId;
                //workOld.EmployeeId = work.EmployeeId;
                await context.SaveChangesAsync();
            }
        }
    }
}
