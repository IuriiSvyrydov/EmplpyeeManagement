using EmployeeManagement.Domain.Entities.Users;
using EmployeeManagement.Persistence.Frameworks.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Persistence.Identity
{
    public static class RegisterIdentityExtension
    {
        public static IServiceCollection RegisterIdentity(this IServiceCollection services)
        {
             services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 8;
                o.User.RequireUniqueEmail = true;
            })
                 
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
             services.AddIdentityCore<User>();
            return services;

        }
    }
}
