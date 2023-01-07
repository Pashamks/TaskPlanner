
using DataAccessLevel.Interfaces;
using DataAccessLevel.Models;

namespace DataAccessLevel.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private EfCoreDbContext GetContext()
        {
            return new EfCoreDbContext();
        }
        public async Task AddAsync(TaskEntity task)
        {
           using(var context = GetContext())
           {
                context.Tasks.Add(task);
                await context.SaveChangesAsync();
           }
        }

        public async Task DeleteAsync(TaskEntity task)
        {
            using (var context = GetContext())
            {
                context.Tasks.Remove(task);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<TaskEntity>> GetAllAsync()
        {
            using (var context = GetContext())
            {
                return context.Tasks.ToList();
            }
        }

        public async Task UpdateAsync(TaskEntity task)
        {
            using(var context = GetContext())
            {
                var taskOld = context.Tasks.First(x => x.Id == task.Id);
                taskOld.Priority = task.Priority;
                taskOld.HoursEstimate = task.HoursEstimate;
                taskOld.Title = task.Title;
                await context.SaveChangesAsync();
            }
        }
    }
}
