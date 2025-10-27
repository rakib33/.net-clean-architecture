using TopUp.Application.Common.CustomMediator;
using TopUp.Domain.Entities.TopUp;

namespace TopUp.Application.Features.Bank_Account.Queries;
public record BankAccountGetAllQuery(CancellationToken CancellationToken) : IRequest<IEnumerable<BankAccount>>;
