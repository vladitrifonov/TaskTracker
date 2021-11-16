using AutoMapper;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Application.Common.Mapper.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        /// <summary>
        /// Ignoring id for entities for sake of updating.
        /// </summary>
        public AutoMapperConfiguration()
        {
            CreateMap<ProjectEntity, ProjectViewModel>()
            /*.ForMember(x => x.Tasks, opt => opt.Ignore())*/
            .ReverseMap()
            .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<TaskEntity, TaskViewModel>()
            .ReverseMap()
            .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
