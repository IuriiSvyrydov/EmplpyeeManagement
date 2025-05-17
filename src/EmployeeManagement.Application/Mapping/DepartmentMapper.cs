using AutoMapper;
using EmployeeManagement.Application.Features.Departments;
using EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment;
using EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;
using EmployeeManagement.Domain.Entities.Departments;

namespace EmployeeManagement.Application.Mapping
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentResponse>()
                .ForCtorParam("DepartmentId", opt => opt.MapFrom(src => src.DepartmentId.Value))
                .ForCtorParam("Code", opt => opt.MapFrom(src => src.Code.Value))
                .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name.Value));
            CreateMap<CreateDepartmentCommand, Department>().ReverseMap();
            CreateMap<UpdateDepartmentCommand,Department>().ReverseMap();
        }
    }
}