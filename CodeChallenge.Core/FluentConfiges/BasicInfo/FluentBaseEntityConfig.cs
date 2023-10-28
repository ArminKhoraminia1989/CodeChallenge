using CodeChallenge.Core.Entities.BasicInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Core.FluentConfiges.BasicInfo
{
    public class FluentBaseEntityConfig : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.DateCreated).IsRequired();
        }
    }
}
