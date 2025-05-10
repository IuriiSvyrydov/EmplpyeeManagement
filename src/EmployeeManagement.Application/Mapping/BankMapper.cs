
using AutoMapper;
using EmployeeManagement.Application.Features.Banks;
using EmployeeManagement.Application.Features.Banks.Commands.CreateBank;
using EmployeeManagement.Domain.Entities.Banks;

namespace EmployeeManagement.Application.Mapping
{
    public  class BankMapper:Profile
    {
        public BankMapper()
        {
            CreateMap<Bank, BankResponse>()
            .ForMember(dest => dest.Id, opt 
                => opt.MapFrom(src => src.BankId.Value))
            .ForMember(dest => dest.Code, opt 
                => opt.MapFrom(src => src.Code.Value))
            .ForMember(dest => dest.Name, opt
                => opt.MapFrom(src => src.Name.Value))
            .ForMember(dest => dest.AccountNo, opt 
                => opt.MapFrom(src => src.AccountNo.Value));
            CreateMap<CreateBankCommand, Bank>().ReverseMap();
        }
        
    }
}