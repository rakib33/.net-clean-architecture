namespace TopUp.Domain.Entities.TopUp;

public class PurposeType
{
    public int ID { get; set; }
    public string? NAME { get; set; }
    public string BALANCETYPE { get; set; } = null!;
    public int BALANCETYPEID { get; set; }
    public bool ISREMOVED { get; set; }
    public DateTime CREATEDATE { get; set; }
    public int? VoucherType { get; set; }
}
