
using DataAccessLevel.Enums;

namespace DataAccessLevel.Models
{
    public class WorkProcessEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public TaskModelStatus Status { get; set; }

    }
}
