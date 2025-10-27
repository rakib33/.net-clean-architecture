namespace TopUp.Domain.Entities.TopUp;

public class AgentInfo : BaseEntity<long>
{
    public long ApiUserId { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? MobileNo { get; set; }
    public string? AlternativeMobileNo { get; set; }
    public string? Email { get; set; }
    public string? AlternativeEmail { get; set; }
    public string Address { get; set; } = null!;
    public long? ZoneId { get; set; }
    public long? CountryId { get; set; }
    public long? CityId { get; set; }
    public string? PostalCode { get; set; }
    public string? LogoName { get; set; }
    public string? BankDetails { get; set; }
    public string? TradeLicense { get; set; }
    public string? MocatNo { get; set; }
    public DateTime? MocatExpiryDate { get; set; }
    public string? AviationLicense { get; set; }
    public bool IsActive { get; set; }
    public long? AccountManagerId { get; set; }
    public int? MaxSearch { get; set; }
    public bool? IsFareBreak { get; set; }
    public long? CurrencyId { get; set; }
    public decimal? CurrentBalance { get; set; }
    public string? DialCode { get; set; }
    public bool IsSupplierShow { get; set; }
    public string? AgencyName { get; set; }
    public string? Status { get; set; }
    public bool? IsLogoS3 { get; set; }
    public bool? IsLicenseS3 { get; set; }
    public bool? IsAVLisenseS3 { get; set; }
    public decimal CurrentBalanceLoan { get; set; }
    public long? RemovedBy { get; set; }
    public DateTime? RemovedDate { get; set; }
    public bool IsHaultStatus { get; set; }
    public string? UploadedFileTradeLisenceName { get; set; }
    public bool? IsTradeLisenceS3 { get; set; }
    public string? UploadedNidFrontName { get; set; }
    public string? UploadedNidBackName { get; set; }
    public bool? IsNidFrontS3 { get; set; }
    public bool? IsNidBackS3 { get; set; }
    public decimal? HoldBalance { get; set; }
    public string? HoldBalanceReason { get; set; }
    public bool IsAllowedPNRSharing { get; set; }
    public bool IsArchive { get; set; }
    public string? OwnersProfilePicture { get; set; }
    public bool? IsOwnersProfilePictureS3 { get; set; }
}
