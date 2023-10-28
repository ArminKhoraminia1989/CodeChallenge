using CodeChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Core.FluentConfiges
{
    public class FluentDoctorSchedulerConfig : IEntityTypeConfiguration<DoctorScheduler>
    {
        public void Configure(EntityTypeBuilder<DoctorScheduler> builder)
        {

            builder.Property(s => s.StartTime).IsRequired();
            builder.Property(s => s.EndTime).IsRequired();

            #region Relations

            builder.HasOne(s => s.Doctor)
            .WithMany(s => s.DoctorSchedulers)
            .HasForeignKey(s => s.DoctorId).OnDelete(DeleteBehavior.NoAction);

            #endregion

        }
    }
}
