using AutoMapper;
using TaskTracker.Core.Dto;
using TaskTracker.Host.Models;

namespace TaskTracker.Host.MapperConfiguration
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Storage.Entities.Project, ProjectDto>().ReverseMap();
            CreateMap<Storage.Entities.Task, TaskDto>().ReverseMap();

            CreateMap<ProjectDto, Project>().ReverseMap();
            CreateMap<TaskDto, Task>().ReverseMap();
        }
    }
}
