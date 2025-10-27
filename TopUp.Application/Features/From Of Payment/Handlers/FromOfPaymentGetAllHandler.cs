using Microsoft.EntityFrameworkCore;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.From_Of_Payment.Queries;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.From_Of_Payment.Handlers;
public class FromOfPaymentGetAllHandler : IRequestHandler<FromOfPaymentGetAllQuery, IEnumerable<FromOfPayment>>
{
    private readonly IRepository<FromOfPayment> _repo;

    public FromOfPaymentGetAllHandler(IBaseUnitOfWork unitOfWork)
    {
        _repo = unitOfWork.Repository<FromOfPayment>();
    }

    public async Task<IEnumerable<FromOfPayment>> Handle(FromOfPaymentGetAllQuery request, CancellationToken cancellationToken = default)
    {
        var queryable = _repo.GetAllAsync().Result.OrderByDescending(t => t.CreatedDate);
        var response = await queryable.ToListAsync(cancellationToken);
        return response;
    }
}
