using Microsoft.AspNetCore.Mvc;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Payment_Status.Queries;

namespace TopUp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PaymentStatusController : ControllerBase
{
    private readonly IMediator _mediator;
    public PaymentStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-payment-status")]
    public async Task<IActionResult> PaymentStatusGetAll (CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(new PaymentStatusGetAllQuery(cancellationToken), cancellationToken);
        return Ok(data);
    }
}
