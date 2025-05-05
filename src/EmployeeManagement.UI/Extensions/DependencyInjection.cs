using System.Net.Http.Headers;

namespace EmployeeManagement.UI.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddUIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("EmployeeAPI", client =>
        {
            client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7243/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

        return services;
    }

    
}