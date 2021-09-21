

namespace TaskTracker.Core.Dto
{   
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }  
}
