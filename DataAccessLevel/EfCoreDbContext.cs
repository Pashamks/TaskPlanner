
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

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<WorkProcessEntity> WorkProcess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
            base.OnConfiguring(builder);
        }
    }
}
