using Microsoft.EntityFrameworkCore;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Payment_Status.Queries;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.Payment_Status.Handlers;
public class PaymentStatusGetAllHandler : IRequestHandler<PaymentStatusGetAllQuery, IEnumerable<PaymentStatus>>
{
    private readonly IRepository<PaymentStatus> _repo;

    public PaymentStatusGetAllHandler(IBaseUnitOfWork unitOfWork)
    {
        _repo = unitOfWork.Repository<PaymentStatus>();
    }

    public async Task<IEnumerable<PaymentStatus>> Handle(PaymentStatusGetAllQuery request, CancellationToken cancellationToken = default)
    {
        var queryable = await _repo.GetAllAsync();
        var response = await queryable.ToListAsync(cancellationToken);
        return response;
    }
}
