namespace TopUp.Application.DTOs.Response;

public class StandardApiResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public int Status { get; set; }
    public dynamic? Data { get; set; }
    public string? Error { get; set; }

    public StandardApiResponseModel()
    {
    }

    public StandardApiResponseModel(bool isSuccess, string? message, string? errorMessage, dynamic? data = null)
    {
        IsSuccess = isSuccess;
        Status = isSuccess ? 200 : 500;
        Message = message ?? string.Empty;
        Error = errorMessage ?? string.Empty;
        Data = data;
    }

    public StandardApiResponseModel(bool IsSuccess, int status, dynamic? data, string message = "", string error = "")
    {
        this.IsSuccess = IsSuccess;
        this.Status = status;
        this.Data = data;
        this.Message = message;
        this.Error = error;
    }
}
