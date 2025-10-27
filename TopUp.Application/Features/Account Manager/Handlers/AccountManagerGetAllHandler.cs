using Microsoft.EntityFrameworkCore;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Account_Manager.Queries;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.Account_Manager.Handlers;
public class AccountManagerGetAllHandler : IRequestHandler<AccountManagerGetAllQuery, IEnumerable<AccountManager>>
{
    private readonly IRepository<AccountManager> _repo;

    public AccountManagerGetAllHandler(IBaseUnitOfWork unitOfWork)
    {
        _repo = unitOfWork.Repository<AccountManager>();
    }

    public async Task<IEnumerable<AccountManager>> Handle(AccountManagerGetAllQuery request, CancellationToken cancellationToken = default)
    {
        var queryable = _repo.GetAllAsync().Result.OrderByDescending(t => t.CreatedDate);
        var response = await queryable.ToListAsync(cancellationToken);
        return response;
    }
}
