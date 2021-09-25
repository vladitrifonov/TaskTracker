﻿using System.Threading.Tasks;

namespace TaskTracker.Host.ViewModels
{
    public class TaskViewModel
    {
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
