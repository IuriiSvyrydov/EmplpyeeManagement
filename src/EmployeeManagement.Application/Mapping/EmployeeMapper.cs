using AutoMapper;
using EmployeeManagement.Application.Features.Employees;
using EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;
using EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;
using EmployeeManagement.Domain.Entities.Employees;


namespace EmployeeManagement.Application.Mapping;

public class EmployeeMapper : Profile
{
    public EmployeeMapper()
    {
        // Map from Employee to EmployeeResponse
        CreateMap<Employee, EmployeeResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.Value))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.Value))
            .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName.Value))
            .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress.Value))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Value))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Value))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.Value))
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId.Value))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Value));

        // Map from CreateEmployeeCommand to Employee with value object creation
        CreateMap<CreateEmployeeCommand, Employee>().ReverseMap();
        CreateMap<UpdateEmployeeCommand, Employee>().ReverseMap()
            .ForMember(dest => dest.EmployeeId, opt => opt.Ignore()); // Don't map the ID from command);

    }
}