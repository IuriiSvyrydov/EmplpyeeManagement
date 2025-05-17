using EmployeeManagement.Application.Features.Banks.Commands.CreateBank;
using FluentValidation;
using EmployeeManagement.Domain.Entities.Banks;
namespace EmployeeManagement.Application.Features.Banks.Validators
{
    public class BankValidator : AbstractValidator<CreateBankCommand>
    {
        public BankValidator()
        {
           
            RuleFor(b => b.Code).NotEmpty()
            .WithMessage("Code is required")
            .MaximumLength(10)
            .WithMessage("Code must be less than 10 characters");
            RuleFor(b => b.Name).NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(100)
            .WithMessage("Name must be less than 100 characters");
            RuleFor(b => b.AccountNo).NotEmpty()
            .WithMessage("AccountNo is required")
            .MaximumLength(100)
            .WithMessage("AccountNo must be less than 100 characters");
            
        }
        
    }
}