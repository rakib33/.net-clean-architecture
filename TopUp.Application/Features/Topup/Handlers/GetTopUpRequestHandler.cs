using Microsoft.EntityFrameworkCore;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.DTOs.Response;
using TopUp.Application.Features.Topup.Queries;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.Topup.Handlers;
public class GetTopUpRequestHandler : IRequestHandler<GetTopUpRequestQuery, StandardApiResponseModel>
{
    private readonly IRepository<TopUpRequest> _topUpRequest;
    public GetTopUpRequestHandler(IBaseUnitOfWork unitOfWork)
    {
        _topUpRequest = unitOfWork.Repository<TopUpRequest>();
    }

    public async Task<StandardApiResponseModel> Handle(GetTopUpRequestQuery request, CancellationToken cancellationToken = default)
    {
        var queryable = _topUpRequest.GetAllAsync().Result.OrderByDescending(t => t.CreatedDate);
        var response = await queryable.ToListAsync(cancellationToken);
        return new StandardApiResponseModel(true,"Data Retrieved Successfully",null, response);
    }
}
