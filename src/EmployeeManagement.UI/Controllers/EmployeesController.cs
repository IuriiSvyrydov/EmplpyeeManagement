using EmployeeManagement.UI.Services.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.UI.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeApiService _employeeService;

    public EmployeesController(IEmployeeApiService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _employeeService.GetAllEmployeesAsync();
        if (result.IsSuccess)
        {
            return View(result.Value);
        }

        // Обработка ошибки
        return View("Error");
    }
    public async Task<IActionResult>Create()
    {
        return View();
    }
}

    
