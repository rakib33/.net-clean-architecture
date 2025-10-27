namespace TopUp.Application.DTOs.Request;

public class GetTopUpRequest
{
    public bool IsDashboardDetails { get; set; }
    public string? FromDate { get; set; } = string.Empty;
    public string? ToDate { get; set; } = string.Empty;
    public long AgentId { get; set; } = 0;
    public int PageNumber { get; set; } = 1;
    public int PurposeTypeId { get; set; } = 0;
    public int PageSize { get; set; } = 30;
    public int Status { get; set; } = 0;
    public long AccountManagerId { get; set; } = 0;
    public long ZoneId { get; set; } = 0;
    public long FormOfPaymentId { get; set; } = 0;
    public string? LedgerTNXNumber { get; set; } = string.Empty;
    public string? SysTransId { get; set; } = string.Empty;
}
