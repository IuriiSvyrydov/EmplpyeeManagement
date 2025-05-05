using EmployeeManagement.Infrastructure.Options;
using EmployeeManagement.Persistence.Frameworks.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EmployeeManagement.Persistence.Extensions
{
    public static class RegisterDatabaseExtension
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>((serviceProvider, optionsBuilder) =>
            {
                var databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>()
                .Value;
                optionsBuilder.UseSqlServer(databaseOptions.ConnectionString!, options =>
                {
                    options.CommandTimeout(databaseOptions.CommandTimeout);
                    options.EnableRetryOnFailure(databaseOptions.MaxRetryDelay,
                        TimeSpan.FromSeconds(databaseOptions.MaxRetryDelay),
                        Array.Empty<int>());
                  
                });
            });
            return services;

    
        }
    }
}