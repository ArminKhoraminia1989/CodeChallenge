using CodeChallenge.Core.Entities.BasicInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Core.FluentConfiges.BasicInfo
{
    public class FluentDrugConfig : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.Property(d => d.Description).HasMaxLength(250).IsRequired();
            builder.Property(d => d.Price).IsRequired();
        }
    }
}
