namespace TopUp.Domain.Entities.TopUp;

public class AppSettings : BaseEntity<long>
{
    public long Id { get; set; }
    public string Code { get; set; } = null!;
    public string? Purpose { get; set; }
    public string? ZoneId { get; set; }
    public string? DepositTypeId { get; set; }
    public decimal MinimumAmount { get; set; }
    public decimal MaximumAmount { get; set; }
    public decimal CashbackRate { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool IsActive { get; set; }
    public DateTime? RemovedDate { get; set; }
    public long? RemovedBy { get; set; }
}
