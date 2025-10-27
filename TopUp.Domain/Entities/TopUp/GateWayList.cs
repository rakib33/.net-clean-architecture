namespace TopUp.Domain.Entities.TopUp;

public class GateWayList : BaseEntity<long>
{
    public int GateWayTypeId { get; set; }
    public string? ServiceType { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DetailsName { get; set; } = string.Empty;
    public string? GatewayCode { get; set; }
    public decimal ChargePercentage { get; set; }
    public bool IsActive { get; set; }
    public int? ChannelId { get; set; }
    public int? CardId { get; set; }
    public int SerialNo { get; set; }
    public string? GatewayImageName { get; set; }
}
