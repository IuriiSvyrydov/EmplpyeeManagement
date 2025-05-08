using EmployeeManagement.UI.Services.Employees;

public static class RegisterServicesExtensions
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddScoped<IEmployeeApiService, EmployeeApiService>();

        
       services.AddHttpClient("EmployeeAPI", client =>
        {
            client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        });
    }
}