namespace TopUp.Domain.Entities.TopUp;

public class AccountManager : BaseEntity<long>
{
    public string Name { get; set; } = null!;
    public string MobileNo { get; set; } = null!;
    public string Email { get; set; } = null!;
    public long? ZoneIdOld { get; set; }
    public string Office { get; set; } = null!;
    public long? RemovedBy { get; set; }
    public DateTime? RemovedDate { get; set; }
    public string? CountryId { get; set; }
    public string? ZoneId { get; set; }
    public string? ZoneIds { get; set; }
}
