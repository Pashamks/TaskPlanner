using AutoMapper;
using BusinessLogicLevel.Models;
using DataAccessLevel.Models;

namespace BusinessLogicLevel.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskModel, TaskEntity>();
            CreateMap<TaskEntity, TaskModel>();

            CreateMap<WorkProcessModel, WorkProcessEntity>();
            CreateMap<WorkProcessEntity, WorkProcessModel>();

            CreateMap<EmployeeEntity, EmployeeModel>();
            CreateMap<EmployeeModel, EmployeeEntity>();
        }
    }
}
