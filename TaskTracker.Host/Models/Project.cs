using System;
using TaskTracker.Core.Dto;

namespace TaskTracker.Host.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
    }
}
