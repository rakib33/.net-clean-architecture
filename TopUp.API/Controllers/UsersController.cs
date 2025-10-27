using Microsoft.AspNetCore.Mvc;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.User.Queries;

namespace TopUp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-users-info")]
    public async Task<IActionResult> UsersGetAll(CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new UsersGetAllQuery(cancellationToken), cancellationToken);
        return Ok(data);
    }
}
