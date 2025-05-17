using System.Text;
using System.Text.Json;
using EmployeeManagement.UI.Dtos.DepartmentsDtos;
using EmployeeManagement.UI.ErrorModel;
using EmployeeManagement.UI.Models;


namespace EmployeeManagement.UI.Services.Departments;


public class DepartmentApiService : IDepartmentApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public DepartmentApiService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = jsonSerializerOptions;
    }
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

    public async Task<Result<List<DepartmentDto>>> GetAllDepartmentsAsync()
    {
        try
        {
            using var response = await _httpClient.GetAsync("api/department", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<List<DepartmentDto>>>(content, _jsonSerializerOptions);

            return result ??
                   CreateErrorResult<List<DepartmentDto>>("DESERIALIZATION_ERROR", "Desirialization result is null");
        }
        catch (JsonException ex)
        {
            return CreateErrorResult<List<DepartmentDto>>("DESERIALIZATION_ERROR", ex.Message);
        }
        catch (HttpRequestException ex)
        {
            return CreateErrorResult<List<DepartmentDto>>("HTTP_REQUEST_ERROR", ex.Message);
        }
    }
  
    public async Task<Result<DepartmentDto>> GetDepartmentByIdAsync(Guid id)
    {
        try
        {
            using var response =
                await _httpClient.GetAsync($"api/department/{id}", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<DepartmentDto>>(content, _jsonSerializerOptions);

            return result ?? CreateErrorResult<DepartmentDto>(Errors.DESERIALIZATIONERROR, "Desirialization result is null");
        }
        catch (JsonException ex)
        {
            return CreateErrorResult<DepartmentDto>(Errors.DESERIALIZATIONERROR, ex.Message);
        }
        catch (HttpRequestException ex)
        {
            return CreateErrorResult<DepartmentDto>(Errors.HTTPREQUESTERROR, ex.Message);
        }
    }

    public async Task<Result<DepartmentDto>> CreateDepartmentAsync(CreateDepartmentDto department)
    {
          if (department is null)
        {
            return CreateErrorResult<DepartmentDto>(Errors.VALIDATIONERROR, "Department can not be null");
        }

        try
        {
            var json = JsonSerializer.Serialize(department, _jsonSerializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await _httpClient.PostAsync("api/department", content);

            if (!response.IsSuccessStatusCode)
            {
                return CreateErrorResult<DepartmentDto>(Errors.APIERROR,
                    $" Create department error: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<DepartmentDto>>(responseContent, _jsonSerializerOptions);

            return result ?? CreateErrorResult<DepartmentDto>(Errors.DESERIALIZATIONERROR,
                "Internal server error. Desirialization result is null");
        }
        catch (JsonException ex)
        {
            return CreateErrorResult<DepartmentDto>(Errors.DESERIALIZATIONERROR,
                $"Error serialization/ desirialization: {ex.Message}");
        }
        catch (HttpRequestException ex)
        {
            return CreateErrorResult<DepartmentDto>(Errors.HTTPREQUESTERROR,
                $"Error HTTP request: {ex.Message}");
        }
        catch (Exception ex)
        {
            return CreateErrorResult<DepartmentDto>(Errors.UNEXPECTEDERROR,
                $"Unexpected error: {ex.Message}");
        }
    }

    public async Task<Result<DepartmentDto>> UpdateDepartmentAsync(Guid id, UpdateDepartmentDto department)
    {
         if (department == null)
        {
            return CreateErrorResult<DepartmentDto>(Errors.VALIDATIONERROR, "Department can not be empty");
        }

        try
        {
            var json = JsonSerializer.Serialize(department, _jsonSerializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await _httpClient.PutAsync($"api/department/{id}", content);

            if (!response.IsSuccessStatusCode)
            {
                return CreateErrorResult<DepartmentDto>(Errors.APIERROR,
                    $"Error update department. Status code: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<DepartmentDto>>(responseContent, _jsonSerializerOptions);

            return result ?? CreateErrorResult<DepartmentDto>(Errors.DESERIALIZATIONERROR,
                "Internal server error");
        }
        catch (JsonException ex)
        {
            return CreateErrorResult<DepartmentDto>(Errors.DESERIALIZATIONERROR,
                $"Error serealizsation/deserialization: {ex.Message}");
        }
        catch (HttpRequestException ex)
        {
            return CreateErrorResult<DepartmentDto>(Errors.HTTPREQUESTERROR,
                $"Http error request: {ex.Message}");
        }
        catch (Exception ex)
        {
            return CreateErrorResult<DepartmentDto>(Errors.UNEXPECTEDERROR,
                $"Unexpected error: {ex.Message}");
        }
        
    }

    public async Task<Result<bool>> DeleteDepartmentAsync(Guid id)
    {
        try
        {
            using var response = await _httpClient.DeleteAsync($"api/employees/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return CreateErrorResult<bool>("API_ERROR",
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
            return CreateErrorResult<Boolean>(Errors.HTTPREQUESTERROR,
                $"Http Error Request: {ex.Message}");
        }
        catch (Exception ex)
        {
            return CreateErrorResult<Boolean>(Errors.UNEXPECTEDERROR,
                $"Unexpected error: {ex.Message}");
        }
        
    }
}