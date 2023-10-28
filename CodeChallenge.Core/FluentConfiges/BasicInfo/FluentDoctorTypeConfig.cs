using CodeChallenge.Core.Entities.BasicInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Core.FluentConfiges.BasicInfo
{
    public class FluentDoctorTypeConfig : IEntityTypeConfiguration<DoctorType>
    {
        public void Configure(EntityTypeBuilder<DoctorType> builder)
        {

            builder.Property(c => c.Type).IsRequired();
            builder.Property(c => c.MinTimeVisit).IsRequired();
            builder.Property(c => c.MaxTimeVisit).IsRequired();

        }
    }
}
