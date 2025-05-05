namespace EmployeeManagement.UI.Services.Employees;

public interface IEmployeeApiService
{
    Task<TResponse>SendAsync<TResponse,TRequest>(string endpoint, HttpMethod method, TRequest? request = default);
    
}