namespace TopUp.Domain.Entities.TopUp;

public class BankAccount: BaseEntity<long>
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string RoutingNumber { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public string? BranchCode { get; set; }
    public long? CityId { get; set; }
    public string Address { get; set; } = string.Empty;
    public string? SwiftCode { get; set; }
    public bool IsActive { get; set; }
    public long? RemovedBy { get; set; }
    public DateTime? RemovedDate { get; set; }
}
