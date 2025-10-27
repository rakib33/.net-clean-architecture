using Microsoft.AspNetCore.Mvc;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Bank_Account.Queries;

namespace TopUp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BankAccountController : ControllerBase
{
    private readonly IMediator _mediator;
    public BankAccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-bank-account")]
    public async Task<IActionResult> BankAccountGetAll(CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new BankAccountGetAllQuery(cancellationToken), cancellationToken);
        return Ok(data);
    }

}
