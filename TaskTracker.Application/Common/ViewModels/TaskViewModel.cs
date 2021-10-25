using System.Threading.Tasks;

namespace TaskTracker.Application.Common.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
