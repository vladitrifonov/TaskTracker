using AutoMapper;
using TaskTracker.Contracts.DataTypes;

namespace TaskTracker.Host.MapperConfiguration
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Core.Entitiies.Project, Project>().ReverseMap();
            CreateMap<Core.Entitiies.Task, Task>().ReverseMap();
        }
    }
}
