using AutoMapper;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Application.Common.Mapper.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<ProjectEntity, ProjectViewModel>()
             .ForMember(x => x.Tasks, opt => opt.Ignore()) 
             .ReverseMap();

            CreateMap<TaskEntity, TaskViewModel>()          
           .ReverseMap();
        }
    }
}
