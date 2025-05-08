namespace EmployeeMamagement.App.Extensions;

public static class RegisterCorsExtensions
{
    public static IServiceCollection RegisterCors(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowUIOrigin", builder =>
            {
                builder.WithOrigins("https://localhost:5077")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });
        return services;
    }
    
}