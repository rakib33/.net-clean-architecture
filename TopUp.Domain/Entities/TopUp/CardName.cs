namespace TopUp.Domain.Entities.TopUp;

public class CardName
{
    public long Id { get; set; }
    public string CardNameValue { get; set; } = string.Empty; // Renamed property to avoid conflict with class name
    public bool IsActive { get; set; }
    public bool IsRemoved { get; set; }
    public long CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public long? ModifiedBy { get; set; }
    public DateTime? ModefiedDate { get; set; } // Matches SQL column name
}
