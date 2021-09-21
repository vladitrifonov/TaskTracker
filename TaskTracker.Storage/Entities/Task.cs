using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Storage.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public int Priority { get; set; }  
        public Project Project { get; set; }
    }
}
