using TaskTracker.Application.Core.Base.EventHandlers;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Core.Projects.EventHandlers
{
    public class ProjectCreatedEventHandler : BaseCreatedEventHandler<ProjectEntity>
    {
        public ProjectCreatedEventHandler(INotification notification) : base (notification)
        {
        }
    }
}
