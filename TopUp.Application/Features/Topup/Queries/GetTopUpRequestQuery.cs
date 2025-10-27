using TopUp.Application.Common.CustomMediator;
using TopUp.Application.DTOs.Request;
using TopUp.Application.DTOs.Response;

namespace TopUp.Application.Features.Topup.Queries;
public record GetTopUpRequestQuery(GetTopUpRequest dto) : IRequest<StandardApiResponseModel>;
