using EmployeeManagement.UI.Dtos;
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

 
        return View("Error");
    }
    public async Task<IActionResult>Details(Guid id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var result = await _employeeService.GetEmployeeByIdAsync(id);
        return View(result.Value);

    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateEmployeeDto employee)
    {
        if (!ModelState.IsValid)
        {
            return View(employee);
        }
        var result = await _employeeService.CreateEmployeeAsync(employee);
        if (result.IsSuccess)
        {
            return RedirectToAction("Index");
        }
        ModelState.AddModelError("", result.Error.Message);
        return View(employee);

      

    }
    public  async Task<IActionResult>Update()
    {
        return View();
    }
    public async Task<IActionResult>Delete()
    {
        return View();
    }
}

    
