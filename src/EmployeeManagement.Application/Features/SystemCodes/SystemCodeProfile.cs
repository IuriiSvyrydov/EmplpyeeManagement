using AutoMapper;
using EmployeeManagement.Application.Features.SystemCodes;
using EmployeeManagement.Domain.Entities.SystemCodes;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;

namespace EmployeeManagement.Application.Features.SystemCodes
{
    public class SystemCodeProfile : Profile
    {
        public SystemCodeProfile()
        {
            CreateMap<SystemCode, SystemCodeResponse>()
                .ForMember(dest => dest.SystemCodeId, opt => opt.MapFrom(src => src.SystemCodeId.Value))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code.Value))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Value));
        }
    }
}
