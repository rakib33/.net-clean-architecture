namespace TopUp.Domain.Entities.TopUp;

public class GatewayListType
{
    public long Id { get; set; }
    public int? GateWayTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public long CreatedBy { get; set; }
}
