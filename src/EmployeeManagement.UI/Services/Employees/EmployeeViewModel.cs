namespace EmployeeManagement.UI.Services.Employees;

public class EmployeeViewModel
{
    private readonly IEmployeeApiService _employeeApiService;

    public EmployeeViewModel(IEmployeeApiService employeeApiService)
    {
        _employeeApiService = employeeApiService;
    }
    //public async Task<List<Employee>> GetEmployeesAsync()
    //{
    //    return await _apiService.SendAsync<List<Employee>, object>(
    //        "api/employees",
    //        HttpMethod.Get);
    //}

    //public async Task CreateEmployeeAsync(CreateEmployeeRequest request)
    //{
    //    await _apiService.SendAsync<EmptyResponse, CreateEmployeeRequest>(
    //        "api/employees",
    //        HttpMethod.Post,
    //        request);
    //}

    
}