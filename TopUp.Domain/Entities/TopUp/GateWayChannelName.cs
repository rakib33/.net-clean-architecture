namespace TopUp.Domain.Entities.TopUp;

public class GateWayChannelName
{
    public long Id { get; set; }
    public string ChannelName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsRemoved { get; set; }
    public long CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public long? ModifiedBy { get; set; }
    public DateTime? ModefiedDate { get; set; } // Keeping SQL's original column name
}
