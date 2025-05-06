using EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees;

namespace EmployeeManagement.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediatr;

    public EmployeeController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet]
    [Route("GetAllEmployees")]
    public async Task<IActionResult>GetAllEmployees()
    {
        var response = await _mediatr.Send(new GetAllEmployeesQuery());
        return Ok(response);
    }
    [HttpGet]
    [Route("GetEmployee/{employeeId:guid}")]
    public async Task<IActionResult>GetEmployee(Guid employeeId)
    {
        var response = await _mediatr.Send(new GetEmployeeByIdQuery(employeeId));
        return Ok(response);
    }
    
   
}
