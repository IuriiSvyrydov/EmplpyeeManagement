
using EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment;
using EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments;
using EmployeeManagement.Application.Features.Departments.Queries.GetDepartment;
using EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;

namespace EmployeeManagement.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediatr;
        
        public DepartmentController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var response = await _mediatr.Send(new GetAllDepartmentsQuery());
            return Ok(response);
        }    
        [HttpGet("{departmentId:guid}")]
        public async Task<IActionResult> GetDepartment(Guid departmentId)
        {
            var response = await _mediatr.Send(new GetDepartmentQuery(departmentId));
            return Ok(response);
        }
        [HttpPost(Name ="CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentCommand command)
        {
            var response = await _mediatr.Send(command);
            return Ok(response);
        }
        [HttpPut("{departmentId:guid}")]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentCommand command)
        {
            var response = await _mediatr.Send(command);
            return Ok(response);
        }
        [HttpDelete("{departmentId:guid}")]
        public async Task<IActionResult> DeleteDepartment(Guid departmentId)
        {
            var response = await _mediatr.Send(new DeleteDepartmentCommand(departmentId));
            return Ok(response);
        }
    }
}