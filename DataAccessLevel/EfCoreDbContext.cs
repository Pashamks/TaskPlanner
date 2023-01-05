
using DataAccessLevel.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLevel
{
    public class EfCoreDbContext : DbContext
    {
        private readonly string _connectionString =
        "Server=DESKTOP-SM098C1;Database=TaskPlanner;Trusted_Connection=True;";

        public EfCoreDbContext()
        {
        }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<WorkProcessModel> WorkProcess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
            base.OnConfiguring(builder);
        }
    }
}
