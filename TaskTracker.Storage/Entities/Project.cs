using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Storage.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset CompletionDate { get; set; }
        [StringLength(250)]
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
