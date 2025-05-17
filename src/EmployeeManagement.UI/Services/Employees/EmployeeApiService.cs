using System.Text;
using EmployeeManagement.UI.Dtos;
using System.Text.Json;
using EmployeeManagement.UI.ErrorModel;
using EmployeeManagement.UI.Models;

namespace EmployeeManagement.UI.Services.Employees;

public class EmployeeApiServiceBase
{
    protected static Result<T> CreateErrorResult<T>(string code, string message)
    {
        return new Result<T>
        {
            Value = default,
            IsSuccess = false,
            IsFailure = true,
            Error = new Error(code, message)
        };
    }
}

public class EmployeeApiService : EmployeeApiServiceBase, IEmployeeApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public EmployeeApiService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = jsonSerializerOptions;
    }

    public async Task<Result<List<EmployeeDto>>> GetAllEmployeesAsync()
    {
        try
        {
            using var response = await _httpClient.GetAsync("api/employees", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<List<EmployeeDto>>>(content, _jsonSerializerOptions);

            return result ??
                   CreateErrorResult<List<EmployeeDto>>("DESERIALIZATION_ERROR", "Desirialization result is null");
        }
        catch (JsonException ex)
        {
            return CreateErrorResult<List<EmployeeDto>>("DESERIALIZATION_ERROR", ex.Message);
        }
        catch (HttpRequestException ex)
        {
            return CreateErrorResult<List<EmployeeDto>>("HTTP_REQUEST_ERROR", ex.Message);
        }
    }

    public async Task<Result<EmployeeDto>> GetEmployeeByIdAsync(Guid id)
    {
        try
        {
            using var response =
                await _httpClient.GetAsync($"api/employees/{id}", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<EmployeeDto>>(content, _jsonSerializerOptions);

            return result ?? CreateErrorResult<EmployeeDto>(Errors.DESERIALIZATIONERROR, "Desirialization result is null");
        }
        catch (JsonException ex)
        {
            return CreateErrorResult<EmployeeDto>(Errors.DESERIALIZATIONERROR, ex.Message);
        }
        catch (HttpRequestException ex)
        {
            return CreateErrorResult<EmployeeDto>(Errors.HTTPREQUESTERROR, ex.Message);
        }
    }

    public async Task<Result<EmployeeDto>> CreateEmployeeAsync(CreateEmployeeDto employee)
    {
        if (employee is null)
        {
            return CreateErrorResult<EmployeeDto>(Errors.VALIDATIONERROR, "Employee can not be null");
        }

        try
        {
            var json = JsonSerializer.Serialize(employee, _jsonSerializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await _httpClient.PostAsync("api/employees", content);

            if (!response.IsSuccessStatusCode)
            {
                return CreateErrorResult<EmployeeDto>(Errors.APIERROR,
                    $" Create employee error: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<EmployeeDto>>(responseContent, _jsonSerializerOptions);

            return result ?? CreateErrorResult<EmployeeDto>(Errors.DESERIALIZATIONERROR,
                "Internal server error. Desirialization result is null");
        }
        catch (JsonException ex)
        {
            return CreateErrorResult<EmployeeDto>(Errors.DESERIALIZATIONERROR,
                $"Error serialization/ desirialization: {ex.Message}");
        }
        catch (HttpRequestException ex)
        {
            return CreateErrorResult<EmployeeDto>(Errors.HTTPREQUESTERROR,
                $"Error HTTP request: {ex.Message}");
        }
        catch (Exception ex)
        {
            return CreateErrorResult<EmployeeDto>(Errors.UNEXPECTEDERROR,
                $"Unexpected error: {ex.Message}");
        }
    }

    public async Task<Result<EmployeeDto>> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto employee)
    {
        if (employee == null)
        {
            return CreateErrorResult<EmployeeDto>(Errors.VALIDATIONERROR, "Employee can not be empty");
        }

        try
        {
            var json = JsonSerializer.Serialize(employee, _jsonSerializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await _httpClient.PutAsync($"api/employees/{id}", content);

            if (!response.IsSuccessStatusCode)
            {
                return CreateErrorResult<EmployeeDto>(Errors.APIERROR,
                    $"Error update employee. Status code: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<EmployeeDto>>(responseContent, _jsonSerializerOptions);

            return result ?? CreateErrorResult<EmployeeDto>(Errors.DESERIALIZATIONERROR,
                "Internal server error");
        }
        catch (JsonException ex)
        {
            return CreateErrorResult<EmployeeDto>(Errors.DESERIALIZATIONERROR,
                $"Error serealizsation/deserialization: {ex.Message}");
        }
        catch (HttpRequestException ex)
        {
            return CreateErrorResult<EmployeeDto>(Errors.HTTPREQUESTERROR,
                $"Http error request: {ex.Message}");
        }
        catch (Exception ex)
        {
            return CreateErrorResult<EmployeeDto>(Errors.UNEXPECTEDERROR,
                $"Unexpected error: {ex.Message}");
        }
    }

    public async Task<Result<bool>> DeleteEmployeeAsync(Guid id)
    {
        try
        {
            using var response = await _httpClient.DeleteAsync($"api/department/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return CreateErrorResult<bool>(Errors.APIERROR,
                    $"Delete error is failed. Status code: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<bool>>(responseContent, _jsonSerializerOptions);

            return result ?? new Result<bool>
            {
                Value = true,
                IsSuccess = true,
                IsFailure = false,
                Error = null
            };
        }
        catch (HttpRequestException ex)
        {
            return CreateErrorResult<bool>(Errors.HTTPREQUESTERROR,
                $"Http Error Request: {ex.Message}");
        }
        catch (Exception ex)
        {
            return CreateErrorResult<Boolean>(Errors.UNEXPECTEDERROR,
                $"Unexpected error: {ex.Message}");
        }
    }
}


