using Microsoft.AspNetCore.Mvc;
using MediatR;
using EmployeeManagement.Application.Features.SystemCodes.CreateSystemCode;
using EmployeeManagement.Application.Features.SystemCodes.DeleteSystemCode;
using EmployeeManagement.Application.Features.SystemCodes.GetAllSystemCodes;
using EmployeeManagement.Application.Features.SystemCodes.GetSystemCode;
using EmployeeManagement.Application.Features.SystemCodes.UpdateSystemCode;

namespace EmployeeManagement.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SystemCodeController : ControllerBase
{
    private readonly IMediator _mediatr;
    public SystemCodeController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllSystemCodes()
    {
        var response = await _mediatr.Send(new GetAllSystemCodesQuery());
        return Ok(response);
    }
    [HttpGet("{systemCodeId:guid}")]
    public async Task<IActionResult> GetSystemCode(Guid systemCodeId)
    {
        var response = await _mediatr.Send(new GetSystemCodeQuery(systemCodeId));
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateSystemCode(CreateSystemCodeCommand command)
    {
        var response = await _mediatr.Send(command);
        return Ok(response);
    }
    
    [HttpPut("{systemCodeId:guid}")]
    public async Task<IActionResult> UpdateSystemCode(Guid systemCodeId, UpdateSystemCodeCommand command)
    {
        command.SystemCodeId = systemCodeId;
        var response = await _mediatr.Send(command);
        return Ok(response);
    }
    
    [HttpDelete("{systemCodeId:guid}")]
    public async Task<IActionResult> DeleteSystemCode(Guid systemCodeId)
    {
        var response = await _mediatr.Send(new DeleteSystemCodeCommand(systemCodeId));
        return Ok(response);
    }
}