using TopUp.Application.DTOs.Response;
using TopUp.Application.Interfaces;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Services;

public class TopUpServices: ITopUpServices
{
    private readonly IBaseUnitOfWork _unitOfWork;
    private readonly IRepository<TopUpRequest> _TopUpRequest;

    public TopUpServices(IBaseUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _TopUpRequest = _unitOfWork.Repository<TopUpRequest>();
    }

    public async Task<StandardApiResponseModel> GetAllTopupRequestAsync()
    {
        try
        {
            var data = await _TopUpRequest.GetAllAsync();
            return new StandardApiResponseModel
            {
                Status = 200,
                IsSuccess = true,
                Message = "Hello",
                Data = data
            };
        }
        catch (Exception ex)
        {
            return new StandardApiResponseModel
            {
                Status = 500,
                IsSuccess = false,
                Message = "Hello",
                Data = null,
                Error = ex.Message
            };
        }
    }
}
