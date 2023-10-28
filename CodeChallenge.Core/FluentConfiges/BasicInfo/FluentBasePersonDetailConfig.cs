using CodeChallenge.Core.Entities.BasicInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Core.FluentConfiges.BasicInfo
{
    public class FluentBasePersonDetailConfig : IEntityTypeConfiguration<BasePersonDetail>
    {
        public void Configure(EntityTypeBuilder<BasePersonDetail> builder)
        {
            builder.Property(b => b.Age).IsRequired();
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Gender).IsRequired();
            builder.Property(b => b.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(b => b.EmailAddress).HasMaxLength(100).IsRequired();
            builder.Property(b => b.PhoneNumber).HasMaxLength(50).IsRequired();
    }
    }
}
