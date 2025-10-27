namespace TopUp.Domain.Entities.TopUp;

public class TopUpRequest: BaseEntity<long>
{
    public long AgentId { get; set; }
    public string SysTransId { get; set; } = string.Empty;
    public int FOPTypeId { get; set; }
    public string? FOPSubSectionName { get; set; }
    public decimal RequestedAmount { get; set; }
    public decimal AprovalAmount { get; set; }
    public decimal ChargeAmount { get; set; }
    public decimal GatewayChargePercent { get; set; }
    public int PaymentStatusId { get; set; }
    public int AssignApprovarId { get; set; }
    public string? AdminOrAgentRemarks { get; set; }
    public string? ReferenceUser { get; set; }
    public string? ReferenceAdmin { get; set; }
    public string? ChequeNumber { get; set; }
    public string? BankName { get; set; }
    public string? BranchName { get; set; }
    public DateTime? DepositDate { get; set; }
    public int? DepositAccountId { get; set; }
    public int? OTAAccountId { get; set; }
    public string? AttachmentFileName { get; set; }
    public bool IsAttachmentS3 { get; set; }
    public string? DBARemarks { get; set; }
    public string? LedgerTNXNumber { get; set; }
    public long? GatewayId { get; set; }
    public string? AgentTnxNumber { get; set; }
    public string? PurposeTypeCode { get; set; }
    public string? SubPurposeTypeCode { get; set; }
    public string? MobileAccountNumber { get; set; }
}
