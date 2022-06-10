using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamma.Data.Configurations
{
    public class SiteConfiguration : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.HasKey(x => x.SiteId);

            builder.Property(x => x.Name).HasMaxLength(64);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);

            builder.HasOne(x => x.Owner).WithMany().HasForeignKey("OwnerId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Domain).WithMany().HasForeignKey("DomainId").IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
