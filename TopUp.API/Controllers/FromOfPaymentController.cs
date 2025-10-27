using Microsoft.AspNetCore.Mvc;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.From_Of_Payment.Queries;

namespace TopUp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FromOfPaymentController : ControllerBase
{
    private readonly IMediator _mediator;
    public FromOfPaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-from-of-payment")]
    public async Task<IActionResult> FromOfPaymentGetAll(CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new FromOfPaymentGetAllQuery(cancellationToken), cancellationToken);
        return Ok(data);
    }
}
