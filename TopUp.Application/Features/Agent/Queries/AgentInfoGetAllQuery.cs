using TopUp.Application.Common.CustomMediator;
using TopUp.Domain.Entities.TopUp;

namespace TopUp.Application.Features.Agent.Queries;
public record AgentInfoGetAllQuery(CancellationToken CancellationToken) : IRequest<IEnumerable<AgentInfo>>;
