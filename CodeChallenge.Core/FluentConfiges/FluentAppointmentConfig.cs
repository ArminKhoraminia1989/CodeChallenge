using CodeChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Core.FluentConfiges
{
    public class FluentAppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(v => v.DurationTime).IsRequired();
            builder.Property(v => v.StartTime).IsRequired();
            builder.Property(v => v.EndTime).IsRequired();
            builder.Property(v => v.BriefDescriptionSickness).HasMaxLength(100).IsRequired(false);
            builder.Property(v => v.DescriptionOfDoctor).HasMaxLength(250).IsRequired(false);

            #region Relations

            builder.HasOne(v => v.Doctor)
            .WithMany(v => v.Appointment)
            .HasForeignKey(v => v.DoctorId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(v => v.Patient)
            .WithMany(v => v.Appointment)
            .HasForeignKey(v => v.PatientId).OnDelete(DeleteBehavior.NoAction);

            #endregion

        }
    }
}
