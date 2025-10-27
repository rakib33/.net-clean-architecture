namespace TopUp.Domain.Entities.TopUp;

public class Zone: BaseEntity<long>
{
    public string Name { get; set; } = string.Empty;
    public long CountryId { get; set; }
    public string? Area { get; set; }
    public long? RemovedBy { get; set; }
    public DateTime? RemovedDate { get; set; }
}
