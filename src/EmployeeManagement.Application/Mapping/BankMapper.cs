using AutoMapper;
using EmployeeManagement.Application.Features.Banks;
using EmployeeManagement.Application.Features.Banks.Commands.CreateBank;
using EmployeeManagement.Application.Features.Banks.Commands.UpdateBank;
using EmployeeManagement.Domain.Entities.Banks;
using EmployeeManagement.Domain.Entities.Banks.ValueObject;

namespace EmployeeManagement.Application.Mapping
{
    public class BankMapper : Profile
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

            CreateMap<Bank, CreateBankResponse>()
                .ForMember(dest => dest.Id, opt 
                    => opt.MapFrom(src => src.BankId.Value))
                .ForMember(dest => dest.Code, opt 
                    => opt.MapFrom(src => src.Code.Value))
                .ForMember(dest => dest.Name, opt
                    => opt.MapFrom(src => src.Name.Value))
                .ForMember(dest => dest.AccountNo, opt 
                    => opt.MapFrom(src => src.AccountNo.Value));

            CreateMap<CreateBankCommand, Bank>()
                .ForMember(dest => dest.Code, opt 
                    => opt.MapFrom(src => new Code(src.Code)))
                .ForMember(dest => dest.Name, opt 
                    => opt.MapFrom(src => new Name(src.Name)))
                .ForMember(dest => dest.AccountNo, opt 
                    => opt.MapFrom(src => new AccountNo(src.AccountNo)))
                .ForMember(dest => dest.BankId, opt 
                    => opt.MapFrom(src => BankId.NewId()));

            CreateMap<UpdateBankCommand, Bank>()
                .ForMember(dest => dest.Code, opt 
                    => opt.MapFrom(src => new Code(src.Code)))
                .ForMember(dest => dest.Name, opt 
                    => opt.MapFrom(src => new Name(src.Name)))
                .ForMember(dest => dest.AccountNo, opt 
                    => opt.MapFrom(src => new AccountNo(src.AccountNo)));
        }
    }
}