using CodeChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Core.FluentConfiges
{
    public class FluentAppointmentDrugConfig : IEntityTypeConfiguration<AppointmentDrug>
    {
        public void Configure(EntityTypeBuilder<AppointmentDrug> builder)
        {

            builder.Property(v => v.DrugId).IsRequired();
            builder.Property(v => v.Qty).IsRequired();

            #region Relations

            builder.HasOne(v => v.Appointment)
            .WithMany(v => v.AppointmentDrugs)
            .HasForeignKey(v => v.AppointmentId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(v => v.Drug)
            .WithMany(v => v.AppointmentDrugs)
            .HasForeignKey(v => v.DrugId).OnDelete(DeleteBehavior.NoAction);

            #endregion

        }
    }
}
