using Microsoft.EntityFrameworkCore;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Agent.Queries;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.Agent.Handlers;
public class AgentInfoGetAllHandler : IRequestHandler<AgentInfoGetAllQuery, IEnumerable<AgentInfo>>
{
    private readonly IRepository<AgentInfo> _repo;

    public AgentInfoGetAllHandler(IBaseUnitOfWork unitOfWork)
    {
        _repo = unitOfWork.Repository<AgentInfo>();
    }

    public async Task<IEnumerable<AgentInfo>> Handle(AgentInfoGetAllQuery request, CancellationToken cancellationToken = default)
    {
        var queryable = _repo.GetAllAsync().Result.OrderByDescending(t => t.CreatedDate);
        var response = await queryable.ToListAsync(cancellationToken);
        return response;
    }

}
