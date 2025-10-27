using Microsoft.AspNetCore.Mvc;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Account_Manager.Queries;

namespace TopUp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountManagerController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountManagerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-account-manager")]
    public async Task<IActionResult> AccountManagerGetAll(CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new AccountManagerGetAllQuery(cancellationToken), cancellationToken);

        return Ok(data);
    }
}
