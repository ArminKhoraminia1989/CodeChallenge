using CodeChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Core.FluentConfiges
{
    public class FluentDoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(d => d.Age).IsRequired();
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Gender).IsRequired();
            builder.Property(b => b.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(b => b.EmailAddress).HasMaxLength(100).IsRequired();
            builder.Property(b => b.PhoneNumber).HasMaxLength(50).IsRequired();


            #region Relations

            builder.HasOne(d => d.TypeDoctor)
            .WithMany(d => d.Doctors)
            .HasForeignKey(d => d.TypeDoctorId).OnDelete(DeleteBehavior.NoAction);

            #endregion

        }
    }
}
