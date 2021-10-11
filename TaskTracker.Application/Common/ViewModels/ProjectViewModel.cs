using System;
using System.Collections.Generic;
using TaskTracker.Contracts.DataTypes;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Application.Common.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public IEnumerable<TaskEntity> Tasks = new List<TaskEntity>();
    }
}
