using Microsoft.EntityFrameworkCore;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.User.Queries;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.User.Handlers;
public class UsersGetAllHandler : IRequestHandler<UsersGetAllQuery, IEnumerable<Users>>
{
    private readonly IRepository<Users> _repo;
    public UsersGetAllHandler(IBaseUnitOfWork unitOfWork)
    {
        _repo = unitOfWork.Repository<Users>();
    }

    public async Task<IEnumerable<Users>> Handle(UsersGetAllQuery request, CancellationToken cancellationToken = default)
    {
        var queryable = _repo.GetAllAsync().Result.OrderByDescending(t => t.CreatedDate);
        var response = await queryable.ToListAsync(cancellationToken);
        return response;
    }
}
