using Gamma.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamma.Data.Configurations
{
    public class SitePageConfiguration : IEntityTypeConfiguration<SitePage>
    {
        public void Configure(EntityTypeBuilder<SitePage> builder)
        {
            builder.HasKey(x => x.SitePageId);

            builder.Property(x => x.Name).HasMaxLength(64);
            builder.Property(x => x.Url).HasMaxLength(64);
            builder.Property(x => x.ContentJson).HasMaxLength(5000000);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);

            builder.HasOne(x => x.Site).WithMany(x => x.Pages).HasForeignKey("SiteId").IsRequired();
        }
    }
}
