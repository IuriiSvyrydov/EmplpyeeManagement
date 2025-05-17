using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

using FluentValidation;

using EmployeeManagement.Application.Messaging;

namespace EmployeeManagement.Application.Extensions

{
    public static class RegisterMediatrExtension
    {
        public static IServiceCollection RegisterMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.Scan(scan => scan.FromAssembliesOf(typeof(RegisterMediatrExtension))
 
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.AddValidatorsFromAssembly(typeof(RegisterMediatrExtension).Assembly, includeInternalTypes:true);

           

            return services;
        }
    }
}