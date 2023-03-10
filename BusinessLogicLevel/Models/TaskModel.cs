using DataAccessLevel.Enums;

namespace BusinessLogicLevel.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int HoursEstimate { get; set; }
        public TaskPriority Priority { get; set; }
    }
}
