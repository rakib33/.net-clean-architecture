namespace TopUp.Domain.Entities.TopUp;

public class Users: BaseEntity<long>
{
    public string FullName { get; set; } = null!;
    public string Mobile { get; set; } = null!;
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool IsActive { get; set; }
    public bool IsLocked { get; set; }
    public long RoleId { get; set; }
    public bool IsAgentStaff { get; set; }
    public string? DialCode { get; set; }
    public string? DeviceIds { get; set; }
    public string? LoginProvider { get; set; }
    public string? FbProviderKey { get; set; }
    public string? GlProviderKey { get; set; }
    public string? Code { get; set; }
    public string? EmployeeId { get; set; }
    public long? DepartmentId { get; set; }
    public long? DesignationId { get; set; }
    public string? LogoName { get; set; }
    public bool? IsLogoS3 { get; set; }
    public int? MaxSearch { get; set; }
    public bool? IsFareBreak { get; set; }
    public bool IsSupplierShow { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public bool IsTempInspector { get; set; }
    public string? OTP { get; set; }
    public long? RemovedBy { get; set; }
    public DateTime? RemovedDate { get; set; }
    public bool IsEncrypted { get; set; }
    public int? B2BRoleID { get; set; }
    public bool? RequestedEmailVerification { get; set; }
    public bool? Is2FAActive { get; set; }
    public string? EmailVerificationOTP { get; set; }
    public DateTime? EmailVerificationOTPExpireDate { get; set; }
    public DateTime? RequestedEmailVerificationDate { get; set; }
    public DateTime? EmailVerificationOTPRequestDate { get; set; }
    public bool? EmailVerified { get; set; }
    public DateTime? ActivationDate2FA { get; set; }
    public long? ActivatedBy2FA { get; set; }
    public DateTime? DeActivationDate2FA { get; set; }
    public long? DeActivatedBy2FA { get; set; }
    public DateTime? EmailVerificationDate { get; set; }
    public bool? EveryLogin2FA { get; set; }
    public string? LoginOTP { get; set; }
    public DateTime? LoginOTPExpireDate { get; set; }
    public DateTime? LoginOTPRequestDate { get; set; }
    public Guid? OtpTracker { get; set; }
    public string? OTPRefererAddress { get; set; }
    public int SearchRoleId { get; set; }
    public int? SearchConfigId { get; set; }
    public long? SearchCount { get; set; }
    public int OTPDeliveryMethod { get; set; }
    public bool? IsTicketIssue2FAActive { get; set; }
    public int FailedLoginAttemtCount { get; set; }
    public DateTime? LastFailedLoginTime { get; set; }
    public int LockOutDuration { get; set; }
    public int WrongPasswordResetOtpCount { get; set; }
    public DateTime? PasswordResetWithLinkValidTill { get; set; }
    public int FailedLoginWithOtpCount { get; set; }
    public DateTime? LastFailedLoginWithOtpOn { get; set; }
    public int FailedLoginWithPassCount { get; set; }
    public DateTime? LastFailedLoginWithPassOn { get; set; }
    public bool? IsUserLatLongActive { get; set; }
    public bool OnlyAllowWhiteIp { get; set; }
    public string? ProfilePicName { get; set; }
    public bool IsAccountLocked { get; set; }
    public int Failed2FAOTPAttemptCount { get; set; }
    public DateTime? LastFailed2FAOTPAttemptOn { get; set; }
    public bool? IsSuppressedEmail { get; set; }
    public bool IsAccountUnlockRestricted { get; set; }
    public bool IsArchive { get; set; }
    public string? AuthenticatorToken { get; set; }
}
