namespace TopUp.Domain.Entities.TopUp;

public class TopupRequestLogHistory

{
    public long Id { get; set; }
    public long EventId { get; set; }
    public string? Action { get; set; }
    public string? ActionDetails { get; set; }
    public long StatusBy { get; set; }
    public DateTime StatusDate { get; set; }
    public string? Remarks { get; set; }
}
