using Microsoft.AspNetCore.Mvc;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Agent.Queries;

namespace TopUp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AgentInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public AgentInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-agent-info")]
    public async Task<IActionResult> AgentInfoGetAll(CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new AgentInfoGetAllQuery(cancellationToken), cancellationToken);
        return Ok(data);
    }
}
