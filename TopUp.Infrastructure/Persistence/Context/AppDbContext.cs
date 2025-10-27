using Microsoft.EntityFrameworkCore;
using TopUp.Domain.Entities;
using TopUp.Domain.Entities.TopUp;

namespace TopUp.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<AccountManager> AccountManager => Set<AccountManager>();
        public DbSet<AgentBalanceLog> AgentBalanceLog => Set<AgentBalanceLog>();
        public DbSet<AgentBankAccount> AgentBankAccount => Set<AgentBankAccount>();
        public DbSet<AgentInfo> AgentInfo => Set<AgentInfo>();
        public DbSet<AppSettings> AppSettings => Set<AppSettings>();
        public DbSet<BalanceApprovalTracking> BalanceApprovalTracking => Set<BalanceApprovalTracking>();
        public DbSet<BankAccount> BankAccount => Set<BankAccount>();
        public DbSet<CardName> CardName => Set<CardName>();
        public DbSet<FromOfPayment> FromOfPayment => Set<FromOfPayment>();
        public DbSet<GateWayChannelName> GateWayChannelName => Set<GateWayChannelName>();
        public DbSet<GateWayList> GateWayList => Set<GateWayList>();
        public DbSet<GatewayListType> GatewayListType => Set<GatewayListType>();
        public DbSet<PaymentStatus> PaymentStatus => Set<PaymentStatus>();
        public DbSet<PurposeType> PurposeType => Set<PurposeType>();
        public DbSet<TopUpRequest> TopUpRequest => Set<TopUpRequest>();
        public DbSet<TopupRequestLogHistory> TopupRequestLogHistory => Set<TopupRequestLogHistory>();
        public DbSet<Users> Users => Set<Users>();
        public DbSet<Zone> Zone => Set<Zone>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureTrnSchema(modelBuilder);
        }

        private static void ConfigureTrnSchema(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().ToTable("BankAccount", "trn");
            modelBuilder.Entity<FromOfPayment>().ToTable("FromOfPayment", "trn");
            modelBuilder.Entity<PaymentStatus>().ToTable("PaymentStatus", "trn");
            modelBuilder.Entity<TopUpRequest>().ToTable("TopUpRequest", "trn");
        }
    }
}
