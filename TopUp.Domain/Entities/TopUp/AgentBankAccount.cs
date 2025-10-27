namespace TopUp.Domain.Entities.TopUp;

public class AgentBankAccount : BaseEntity<long>
{
    public long? AgentId { get; set; }
    public string HolderName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string? RoutingNumber { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public string? BranchCode { get; set; }
    public long? CityId { get; set; }
    public string? Address { get; set; }
    public string? SwiftCode { get; set; }
    public bool IsActive { get; set; }
}
