using Microsoft.EntityFrameworkCore;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Topup.Queries;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TopUp.Application.Features.Topup.Handlers;

public class GetAllTopupRequestHandler : IRequestHandler<GetAllTopupRequestQuery, IEnumerable<TopUpRequest>>
{
    private readonly IRepository<TopUpRequest> _topUpRequest;

    public GetAllTopupRequestHandler(IBaseUnitOfWork unitOfWork)
    {
        _topUpRequest = unitOfWork.Repository<TopUpRequest>();
    }

    public async Task<IEnumerable<TopUpRequest>> Handle(GetAllTopupRequestQuery request, CancellationToken cancellationToken = default)
    {
        // Step 1: Get the queryable
        var queryable = await _topUpRequest.GetAllAsync();
        var ordered = queryable.OrderByDescending(t => t.CreatedDate);
        // Step 2: Execute the query asynchronously with cancellation suppor
        return await ordered.ToListAsync(cancellationToken);


    }
}
