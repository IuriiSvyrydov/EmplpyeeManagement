using Microsoft.OpenApi.Models;

namespace EmployeeMamagement.App.Extensions
{
    public static class RegisterSwaggerExtension
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c=>{
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeManagement API", Version = "v1" });   
            });
        }
    }
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c=>{
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeManagement API");
            });
        }
    }
}
