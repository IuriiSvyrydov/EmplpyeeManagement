using System.Net.Http.Headers;
using EmployeeManagement.UI.Services.Employees;

namespace EmployeeManagement.UI.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterUIServices(this IServiceCollection services, IConfiguration configuration)
    {
       services.AddHttpClient<IEmployeeApiService, EmployeeApiService>(client =>
       {
           client.BaseAddress = new Uri("https://localhost:7243/"); // Укажите правильный базовый URL вашего API
           client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
       });
       //  .AddPolicyHandler(GetRetryPolicy()); // Опционально: добавление политики повторных попыток
       return services;

    }
}