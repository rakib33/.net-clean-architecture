using TopUp.Application.Common.CustomMediator;
using TopUp.Domain.Entities.TopUp;

namespace TopUp.Application.Features.Account_Manager.Queries;
public record AccountManagerGetAllQuery(CancellationToken CancellationToken) : IRequest<IEnumerable<AccountManager>>;
