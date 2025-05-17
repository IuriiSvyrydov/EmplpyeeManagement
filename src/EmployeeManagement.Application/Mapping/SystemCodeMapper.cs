using AutoMapper;
using EmployeeManagement.Application.Features.SystemCodes;
using EmployeeManagement.Application.Features.SystemCodes.CreateSystemCode;
using EmployeeManagement.Application.Features.SystemCodes.UpdateSystemCode;
using EmployeeManagement.Domain.Entities.SystemCodes;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;

namespace EmployeeManagement.Application.Mapping;

public class SystemCodeMapper : Profile
{
    public SystemCodeMapper()
    {
        
        CreateMap<SystemCode, SystemCodeResponse>()
            .ForCtorParam("SystemCodeId", opt => opt.MapFrom(src => src.SystemCodeId.Value))
            .ForCtorParam("Code", opt => opt.MapFrom(src => src.Code.Value))
            .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description.Value));
        
        CreateMap<SystemCode,CreateSystemCodeCommand>()
            
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code.Value))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Value));
        
        CreateMap<CreateSystemCodeCommand, SystemCode>()
            .ForMember(dest => dest.SystemCodeId, opt => opt.MapFrom(src => SystemCodeId.NewId()))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => new Code(src.Code)))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => new Description(src.Description)));
        CreateMap<SystemCode,UpdateSystemCodeCommand>()
            .ForMember(dest => dest.SystemCodeId, opt => opt.MapFrom(src => src.SystemCodeId.Value))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code.Value))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Value));

    }
    
    
}