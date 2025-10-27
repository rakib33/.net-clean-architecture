using TopUp.Application.Common.CustomMediator;
using TopUp.Domain.Entities.TopUp;

namespace TopUp.Application.Features.Payment_Status.Queries;
public record PaymentStatusGetAllQuery(CancellationToken CancellationToken) : IRequest<IEnumerable<PaymentStatus>>;
