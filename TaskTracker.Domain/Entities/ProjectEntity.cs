using System;
using TaskTracker.Contracts.DataTypes;

namespace TaskTracker.Contracts.Entities
{
    public class ProjectEntity : BaseEntity
    {
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
    }
}
