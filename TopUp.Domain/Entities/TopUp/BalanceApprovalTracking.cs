namespace TopUp.Domain.Entities.TopUp;

public class BalanceApprovalTracking
{
    public long Id { get; set; }
    public long? BalanceId { get; set; }
    public long? AgentId { get; set; }
    public decimal RequestedAmount { get; set; }
    public decimal BankCharge { get; set; }
    public decimal TopupAmount { get; set; }
    public decimal BalanceAmount { get; set; }
    public int Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? ErrorMessage { get; set; }
    public decimal CurrentBalance { get; set; }
    public bool IsWrongBalance { get; set; }
}
