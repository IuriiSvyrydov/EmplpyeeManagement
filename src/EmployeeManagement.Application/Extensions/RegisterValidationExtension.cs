using FluentValidation;
using EmployeeManagement.Application.Features.Banks.Commands.CreateBank;
using EmployeeManagement.Application.Features.Banks.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Application.Extensions
{
    public static class RegisterValidationExtension
    {
        public static IServiceCollection RegisterValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateBankCommand>, BankValidator>();
            //services.AddScoped<IValidator<UpdateBankCommand>, BankValidator>();
            services.AddValidatorsFromAssembly(typeof(RegisterValidationExtension).Assembly);
            return services;
        }

        
    }
}