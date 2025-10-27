using Microsoft.AspNetCore.Mvc;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Topup.Queries;

namespace TopUp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgentBalanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public AgentBalanceController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("get-topup-request-async")]
    public async Task<IActionResult> GetAllTopupRequestMediatorAsync(CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new GetAllTopupRequestQuery(cancellationToken), cancellationToken);

        return Ok(data);
    }
}
