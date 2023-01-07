using DataAccessLevel.Enums;

namespace BusinessLogicLevel.Models
{
    public class WorkProcessModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public TaskModelStatus Status { get; set; }
    }
}
