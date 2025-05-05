namespace EmployeeManagement.App.Extensions;

public static class RegisterCorsExtensions
{
    public static IServiceCollection RegisterCors(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowUIOrigin", builder =>
            {
                builder.WithOrigins(configuration["AllowedOrigins:UI" ?? "https://localhost:7028"])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });
        return services;
    }
    
}