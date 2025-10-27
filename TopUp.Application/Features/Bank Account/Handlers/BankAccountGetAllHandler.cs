using Microsoft.EntityFrameworkCore;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Bank_Account.Queries;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.Bank_Account.Handlers;
public class BankAccountGetAllHandler : IRequestHandler<BankAccountGetAllQuery, IEnumerable<BankAccount>>
{
    private readonly IRepository<BankAccount> _repo;
    public BankAccountGetAllHandler(IBaseUnitOfWork unitOfWork)
    {
        _repo = unitOfWork.Repository<BankAccount>();
    }

    public async Task<IEnumerable<BankAccount>> Handle(BankAccountGetAllQuery request, CancellationToken cancellationToken = default)
    {
        var queryable = _repo.GetAllAsync().Result.OrderByDescending(t => t.CreatedDate);
        var response = await queryable.ToListAsync(cancellationToken);
        return response;
    }
}
