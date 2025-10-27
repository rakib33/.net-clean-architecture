namespace TopUp.Domain.Entities.TopUp;

public class FromOfPayment : BaseEntity<long>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}