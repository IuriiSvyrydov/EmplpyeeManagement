using EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees;
using EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;
using EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;
using EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployee;

namespace EmployeeManagement.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]

public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediatr;

    public EmployeesController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var response = await _mediatr.Send(new GetAllEmployeesQuery());
        return Ok(response);
    }

    [HttpGet("{employeeId:guid}")]
    public async Task<IActionResult> GetEmployee(Guid employeeId)
    {
        var response = await _mediatr.Send(new GetEmployeeByIdQuery(employeeId));
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand command)
    {
        var response = await _mediatr.Send(command);
        return Ok(response);
    }

    [HttpPut("{employeeId:guid}")]
    public async Task<IActionResult> UpdateEmployee( UpdateEmployeeCommand command)
    {
        var response = await _mediatr.Send(command);
        return Ok(response);
    }

    [HttpDelete("{employeeId:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid employeeId)
    {
        var response = await _mediatr.Send(new DeleteEmployeeCommand(employeeId));
        return Ok(response);
    }
}
