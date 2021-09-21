using TaskTracker.Contracts.DataTypes;

namespace TaskTracker.Storage.Entitiies
{
    public class Task : BaseEntity
    {       
        public int IdProject { get; set; }     
        public string Name { get; set; }
        public TaskStatus Status { get; set; }      
        public string Description { get; set; }
        public int Priority { get; set; }
        public Project Project { get; set; }
    }
}
