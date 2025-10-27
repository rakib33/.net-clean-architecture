using TopUp.Application.Common.CustomMediator;
using TopUp.Domain.Entities.TopUp;

namespace TopUp.Application.Features.User.Queries;
public record UsersGetAllQuery(CancellationToken CancellationToken) : IRequest<IEnumerable<Users>>;
