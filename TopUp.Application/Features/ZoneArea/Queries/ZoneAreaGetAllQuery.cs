using TopUp.Application.Common.CustomMediator;
using TopUp.Domain.Entities.TopUp;

namespace TopUp.Application.Features.ZoneArea.Queries;
public record ZoneGetAllQuery(CancellationToken CancellationToken) : IRequest<IEnumerable<Zone>>;
