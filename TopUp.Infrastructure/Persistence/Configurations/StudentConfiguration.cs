namespace TopUp.Infrastructure.Persistence.Configurations
{
    //public class StudentConfiguration : IEntityTypeConfiguration<Student>
    //{
    //    public void Configure(EntityTypeBuilder<Appointment> builder)
    //    {
    //        builder.HasKey(a => a.Id);

    //        builder.Property(a => a.CreatedDate).IsRequired();

    //        builder.Property(a => a.Status)
    //               .HasConversion<int>()
    //               .IsRequired();

    //        builder.HasOne(a => a.ScheduleSlot)
    //               .WithOne(s => s.Appointment)
    //               .HasForeignKey<Appointment>(a => a.ScheduleSlotId)
    //               .OnDelete(DeleteBehavior.Restrict);

    //        builder.HasOne(a => a.Patient)
    //               .WithMany(p => p.Appointments)
    //               .HasForeignKey(a => a.PatientId)
    //               .OnDelete(DeleteBehavior.Restrict);

    //        // Enforce one appointment per slot
    //        builder.HasIndex(a => a.ScheduleSlotId).IsUnique();

    //        // Fast retrieval of appointments per patient
    //        builder.HasIndex(a => a.PatientId);
    //    }
    //}

}
