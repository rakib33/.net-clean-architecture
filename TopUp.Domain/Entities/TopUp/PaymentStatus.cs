namespace TopUp.Domain.Entities.TopUp;

public class PaymentStatus
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public long CreatedBy { get; set; }
    public bool IsRemoved { get; set; }

}
