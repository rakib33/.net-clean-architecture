using TopUp.Application.Common.CustomMediator;
using TopUp.Domain.Entities.TopUp;

namespace TopUp.Application.Features.Topup.Queries;

public record GetAllTopupRequestQuery(CancellationToken CancellationToken) : IRequest<IEnumerable<TopUpRequest>>;

