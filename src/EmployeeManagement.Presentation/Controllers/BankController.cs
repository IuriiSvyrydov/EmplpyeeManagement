using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Application.Features.Banks.Queries.GetAllBanks;
using EmployeeManagement.Application.Features.Banks.Commands.DeleteBank;
using EmployeeManagement.Application.Features.Banks.Commands.CreateBank;
using EmployeeManagement.Application.Features.Banks.Commands.UpdateBank;
using EmployeeManagement.Application.Features.Banks.Queries.GetBank;


namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public BankController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBanks()
        {
            var response = await _mediatr.Send(new GetAllBanksQuery());
            return Ok(response);
        }

        [HttpGet("{bankId:guid}")]
        public async Task<IActionResult> GetBank(Guid bankId)
        {
            var response = await _mediatr.Send(new GetBankQuery(bankId));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBank(CreateBankCommand command)
        {
            var response = await _mediatr.Send(command);
            return Ok(response);
        }

        [HttpPut("{bankId:guid}")]
        public async Task<IActionResult> UpdateBank(UpdateBankCommand command)
        {
            var response = await _mediatr.Send(command);
            return Ok(response);
        }

        [HttpDelete("{bankId:guid}")]
        public async Task<IActionResult> DeleteBank(Guid bankId)
        {
            var response = await _mediatr.Send(new DeleteBankCommand(bankId));
            return Ok(response);
        }
    }
}