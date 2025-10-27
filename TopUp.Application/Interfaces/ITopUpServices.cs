using TopUp.Application.DTOs.Response;

namespace TopUp.Application.Interfaces;

public interface ITopUpServices
{
    Task<StandardApiResponseModel> GetAllTopupRequestAsync();
}
