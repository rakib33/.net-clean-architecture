using Microsoft.AspNetCore.Mvc;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.ZoneArea.Queries;

namespace TopUp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ZoneController : ControllerBase
{
    private readonly IMediator _mediator;
    public ZoneController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-zone")]
    public async Task<IActionResult> ZoneGetAll(CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new ZoneGetAllQuery(cancellationToken), cancellationToken);
        return Ok(data);
    }
}
