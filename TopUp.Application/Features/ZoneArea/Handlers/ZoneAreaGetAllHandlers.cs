using Microsoft.EntityFrameworkCore;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.ZoneArea.Queries;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.ZoneArea.Handlers;
public class ZoneAreaGetAllHandlers : IRequestHandler<ZoneGetAllQuery, IEnumerable<Zone>>
{
    private readonly IRepository<Zone> _repo;

    public ZoneAreaGetAllHandlers(IBaseUnitOfWork unitOfWork)
    {
        _repo = unitOfWork.Repository<Zone>();
    }

    public async Task<IEnumerable<Zone>> Handle(ZoneGetAllQuery request, CancellationToken cancellationToken = default)
    {
        var queryable = _repo.GetAllAsync().Result.OrderByDescending(x=>x.CreatedDate);
        var response = await queryable.ToListAsync(cancellationToken);
        return response;
    }
}
