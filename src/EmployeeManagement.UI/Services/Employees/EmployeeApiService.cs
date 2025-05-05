using System.Text;
using System.Text.Json;

namespace EmployeeManagement.UI.Services.Employees;

public class EmployeeApiService:IEmployeeApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EmployeeApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<TResponse> SendAsync<TResponse, TRequest>(string endpoint, HttpMethod method, TRequest? request = default)
    {
        var client = _httpClientFactory.CreateClient("EmployeeAPI");
        var httpRequest = new HttpRequestMessage(method, endpoint);
        if (request !=null)
        {
            httpRequest.Content = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");
        }
        var response = await client.SendAsync(httpRequest);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(responseContent)!;


    }
}