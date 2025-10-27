using TopUp.Application.Common.CustomMediator;
using TopUp.Domain.Entities.TopUp;

namespace TopUp.Application.Features.From_Of_Payment.Queries;
public record FromOfPaymentGetAllQuery(CancellationToken CancellationToken) : IRequest<IEnumerable<FromOfPayment>>;
